using Microsoft.Data.Sqlite;

namespace Zot2Bib;

public class ZotDb
{
    private readonly SqliteConnection _connection;
    private readonly SqlScripts _sqlScripts = new();

    public ZotDb(String dbpath)
    {
        _connection = new SqliteConnection($"Data Source={dbpath};Mode=ReadOnly");
        _connection.Open();
        Console.WriteLine(_connection.DataSource);
    }

    public List<String> GetFields()
    {
        var command = _connection.CreateCommand();
        command.CommandText = """
            SELECT fieldName FROM fieldsCombined;
            """;

        using var reader = command.ExecuteReader();

        var ret = new List<String>();

        while (reader.Read())
        {
            ret.Add(reader.GetString(0));
        }

        return ret;
    }

    public void PrintAuthors()
    {
        var command = _connection.CreateCommand();
        command.CommandText = _sqlScripts.Get(SqlScripts.Enum.GetAllFields);
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

    public void Iterating()
    {
        var command = _connection.CreateCommand();
        command.CommandText = _sqlScripts.Get(SqlScripts.Enum.GetAllFields);
        using var reader = command.ExecuteReader();

        var fieldNameToIndex = Enumerable
            .Range(0, reader.FieldCount)
            .ToDictionary(i => reader.GetName(i), i => i);
        ;
        var indexToFieldName = Enumerable
            .Range(0, reader.FieldCount)
            .ToDictionary(i => i, i => reader.GetName(i));

        var allItems = new List<ZotItem>();
        while (reader.Read())
        {
            var item = new ZotItem();
            for (var i = 0; i < reader.FieldCount; i++)
            {
                if (!reader.IsDBNull(i))
                {
                    item.SetField(indexToFieldName[i], reader.GetString(i));
                }
            }
            allItems.Add(item);
        }
        Console.WriteLine(allItems);
    }

    public void GenerateZotItem()
    {
        foreach (var field in GetFields())
        {
            Console.WriteLine($"public string? {CapFirst(field)} {{ get; set; }}");
        }
    }

    public void GenerateGroupCons()
    {
        foreach (var field in GetFields())
        {
            Console.WriteLine(
                $"group_concat(CASE WHEN fieldname = '{field}' THEN itemdatavalues.value END) AS '{field}' ,"
            );
        }
    }

    public void GenerateFieldList()
    {
        foreach (var field in GetFields())
        {
            Console.Write($"'{field}',");
        }
    }

    public void GenerateZotItemAssignment()
    {
        foreach (var field in GetFields())
        {
            Console.WriteLine($"\"{field.ToLower()}\" => {CapFirst(field)} = value, ");
        }
    }

    String CapFirst(String s)
    {
        return String.Concat(s[0].ToString().ToUpper(), s.AsSpan(1));
    }
}
