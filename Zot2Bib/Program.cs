using Microsoft.Data.Sqlite;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Zot2Bib;

internal static class Program
{

    public class CfgJson
    {
        [JsonPropertyName("zotero.sqlite")]
        public required string ZoteroSqliteLocation { get; init; }
    }


    private static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Need cfg file.");
            Environment.Exit(1);
        }

        var cfg = JsonSerializer.Deserialize<CfgJson>(File.ReadAllText(args[0]));
        if (cfg is null)
        {  
            Console.WriteLine("cfg unparsable.");
            Environment.Exit(1);
        }

        var connection = new SqliteConnection($"Data Source={cfg.ZoteroSqliteLocation};Mode=ReadOnly");
        connection.Open();

        Console.WriteLine(connection.DataSource);

        var command = connection.CreateCommand();
        command.CommandText = """
        DROP VIEW IF EXISTS mainTable;
        CREATE TEMPORARY VIEW IF NOT EXISTS mainTable (
          itemID, title, type, date, url, doi
        ) AS SELECT
          items.itemid,
          group_concat(CASE WHEN fieldname = 'title' THEN itemdatavalues.value END) AS title,
          group_concat(CASE WHEN fieldname = 'type' THEN itemdatavalues.value END) AS type,
          group_concat(CASE WHEN fieldname = 'date' THEN itemdatavalues.value END) AS date,
          group_concat(CASE WHEN fieldname = 'url' THEN itemdatavalues.value END) AS url,
          group_concat(CASE WHEN fieldname = 'DOI' THEN itemdatavalues.value END) AS doi
        FROM
          items
        LEFT JOIN itemdata ON items.itemid = itemdata.itemid
        LEFT JOIN fieldscombined ON itemdata.fieldid = fieldscombined.fieldid
        LEFT JOIN itemdatavalues ON itemdata.valueid = itemdatavalues.valueid
        GROUP BY items.itemid;
        
        SELECT
          mainTable.*,
          json_group_array(json_object('f', creators.firstName, 'l', creators.lastName, 'm', creators.fieldMode))
        FROM mainTable
        LEFT JOIN itemCreators ON mainTable.itemID = itemCreators.itemID
        LEFT JOIN creators ON itemCreators.creatorID = creators.creatorID
        GROUP BY
          mainTable.itemID;
        """;

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {

            var t = new List<string>();
            for (var i = 0; i < reader.FieldCount; i++)
            {
                if (!reader.IsDBNull(i))
                {
                    t.Add(reader.GetString(i));
                }
            }

            foreach (var s in t)
            {
                Console.Write(s);
                Console.Write(" ");
            }
            Console.WriteLine();

        }

        for (var i = 0; i < reader.FieldCount; i++)
        {
            Console.Write(reader.GetName(i));
            Console.Write(" ");
        }



    }
}
