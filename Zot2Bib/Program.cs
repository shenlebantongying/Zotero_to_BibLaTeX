using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Data.Sqlite;

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

        var zotDb = new ZotDb(cfg.ZoteroSqliteLocation);
        zotDb.PrintFields();
    }
}
