global using ZotAuthorList = System.Collections.Generic.IList<Zot2Bib.ZotAuthor?>;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Zot2Bib;

public static class ZotAuthorListExtensions
{
    public static String? ToBibAuthorList(this ZotAuthorList l)
    {
        if (l.Count == 0 || l[0] == null)
        {
            return null;
        }

        // FIXME: edge case of `and` in name
        // FIXME: or use biblatex's verbose name format?
        String ret = String.Join(
            " and ",
            l.Select(o =>
                {
                    if (o is not null)
                    {
                        return o.Value.TotSimpleString();
                    }

                    return null;
                })
                .Where(o => o is not null)
        );

        return ret.Length == 0 ? null : ret;
    }
}

public struct ZotAuthor()
{
    [JsonPropertyName("f")]
    public String? FirstName { get; init; }

    [JsonPropertyName("l")]
    public String? LastName { get; init; }

    [JsonPropertyName("m")]
    public int Mode { get; init; }

    public static ZotAuthorList FromJsonString(String j)
    {
        var o = JsonSerializer.Deserialize<ZotAuthorList>(j);
        if (o is null)
        {
            throw new Exception("Failed to decode author json");
        }

        return o;
    }

    public String? TotSimpleString()
    {
        if (FirstName is null)
        {
            if (LastName is null)
            {
                return null;
            }

            return LastName;
        }

        return $"{FirstName} {LastName}";
    }
}
