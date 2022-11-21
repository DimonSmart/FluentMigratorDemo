using CommandLine;

namespace FluentMigratorDemo.Options
{
    [Verb("down", HelpText = "Downgrade database.")]
    public class DownOptions
    {
        [Option(Required = true, HelpText = "Downgrade to specified migration number")]
        public int DownTo { get; set; }
    }
}