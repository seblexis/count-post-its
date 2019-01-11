using CommandLine;

namespace CountPostIts.ConsoleUI.Entities
{
    public class Options
    {
        [Value(0, Required = true, HelpText = "The filename to analyse.")]
        public string FileName { get; set; }
    }
}
