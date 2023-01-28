using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using SharpHook;

namespace GameController.Global
{
    internal class AppInfo
    {
        static internal string Path = AppDomain.CurrentDomain.BaseDirectory;
        static internal Setting Setting { get; set; } = null!;
        
        static internal JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.CjkCompatibilityIdeographs, UnicodeRanges.CjkSymbolsandPunctuation),
            IgnoreReadOnlyProperties = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true,
        };
        
        static internal string Url { get; set; } = "";
        static internal bool AutoOpen { get; set; }
        
        
        static internal EventSimulator EventSimulator = new();
    }
}