using System.Text;

namespace Zot2Bib;

public class BibWriter
{
    public static void PrintItem(ZotItem z)
    {
        String? authorStr = null;
        if (z.AuthorJson is not null)
        {
            var a = ZotAuthor.FromJsonString(z.AuthorJson);
            if (a.Count > 0)
            {
                var t = a.ToBibAuthorList();
                if (t is not null)
                {
                    authorStr = t;
                }
            }
        }

        // produce a tag
        // TODO: lots of work needed here.
        List<String> tagParts = [];
        {
            if (authorStr is not null && authorStr.Length > 0)
            {
                tagParts.Add(authorStr.Length < 5 ? authorStr : authorStr.Substring(0, 5));
            }

            if (z.Title is not null && z.Title.Length > 0)
            {
                tagParts.Add(z.Title.Length < 5 ? z.Title : z.Title.Substring(0, 5));
            }

            if (z.Date is not null)
            {
                tagParts.Add(z.Date);
            }

            if (tagParts.Count == 0)
            {
                tagParts.Add("ZeroDataForTag");
            }

            if (z.Title == "A Reference Grammar of French")
            {
                Console.Write("");
            }
        }
        StringBuilder s = new StringBuilder();

        s.Append($"@article{{{String.Join('_', tagParts).Replace(' ', '_')}\n");
        s.Append($"\tTitle = {{{z.Title}}},\n");
        if (authorStr is not null)
        {
            s.Append($"\tAuthor = {{{authorStr}}}\n");
        }

        s.Append("}\n");

        Console.WriteLine(s);
    }
}
