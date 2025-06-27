using System.Reflection;

namespace Zot2Bib;

public class SqlScripts
{
    public enum Enum
    {
        GetAllFields,
    }

    private static String ScriptName(Enum e) =>
        e switch
        {
            Enum.GetAllFields => "Zot2Bib.GetAllFields.sql",
            _ => throw new Exception(),
        };

    private static readonly Assembly RefAssembly = Assembly.GetExecutingAssembly();

    public String Get(Enum e)
    {
        var resName = ScriptName(e);
        using var stream = RefAssembly.GetManifestResourceStream(resName);
        if (stream is null)
        {
            throw new Exception($"No {resName},");
        }
        var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
