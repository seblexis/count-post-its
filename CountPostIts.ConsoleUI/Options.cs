using CommandLine;

namespace CountPostIts.ConsoleUI
{
    public class Options
    {
        [Value(0, Required = true, HelpText = "The filename to analyse.")]
        public string FileName { get; set; }

        [Value(1, Required = true, HelpText = "Enter colour value for Red")]
        public int rVal { get; set; }

        [Value(2, Required = true, HelpText = "Enter colour value for Green")]
        public int gVal { get; set; }

        [Value(3, Required = true, HelpText = "Enter colour value for Blue")]
        public int bVal { get; set; }
    }
}
