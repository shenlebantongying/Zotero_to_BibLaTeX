using System.Text.Json;
using System.Text.Json.Serialization;

namespace Zot2Bib;

internal static class Program
{
    public class CfgJson
    {
        [JsonPropertyName("zotero.sqlite")]
        public required String ZoteroSqliteLocation { get; init; }
    }

    private static void Main(String[] args)
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
        zotDb.Iterating();
    }
}
