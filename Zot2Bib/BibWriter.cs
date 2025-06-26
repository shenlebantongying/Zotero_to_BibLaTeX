using System.Text;

namespace Zot2Bib;

public class BibWriter
{
    public void PrintItem()
    {
        StringBuilder s = new StringBuilder();

        s.Append("@article{");

        s.Append("\n}");

        Console.WriteLine(s);
    }
}
