using Microsoft.Data.Sqlite;

namespace Zot2Bib;

public class ZotDb
{
    SqliteConnection Connection;

    public ZotDb(string dbpath)
    {
        this.Connection = new SqliteConnection($"Data Source={dbpath};Mode=ReadOnly");
        Connection.Open();
        Console.WriteLine(Connection.DataSource);
    }

    public List<string> GetFields()
    {
        var command = Connection.CreateCommand();
        command.CommandText = """
            SELECT fieldName FROM fieldsCombined
            """;
        using var reader = command.ExecuteReader();

        var ret = new List<string>();

        while (reader.Read())
        {
            ret.Add(reader.GetString(0));
        }

        return ret;
    }

    public void PrintFields()
    {
        foreach (var field in GetFields())
        {
            Console.WriteLine(
                $"public string? {string.Concat(field[0].ToString().ToUpper(), field.AsSpan(1))} {{ get; set; }}"
            );
        }
    }

    public void PrintStaffs()
    {
        var command = Connection.CreateCommand();
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
              json_group_array(json_object('f', creators.firstName, 'l', creators.lastName, 'm', creators.fieldMode)) as authors
            FROM mainTable
            LEFT JOIN itemCreators ON mainTable.itemID = itemCreators.itemID
            LEFT JOIN creators ON itemCreators.creatorID = creators.creatorID
            GROUP BY
              mainTable.itemID;
            """;

        using var reader = command.ExecuteReader();

        var fieldNameToIndex = Enumerable
            .Range(0, reader.FieldCount)
            .ToDictionary(i => reader.GetName(i), i => i);

        while (reader.Read())
        {
            var s = reader.GetString(fieldNameToIndex["itemID"]);
            var authors = reader.GetString(fieldNameToIndex["authors"]);

            Console.WriteLine(s);
            Console.WriteLine(authors);
        }
    }
}
