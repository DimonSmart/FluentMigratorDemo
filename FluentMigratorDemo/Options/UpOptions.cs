using CommandLine;

namespace FluentMigratorDemo.Options
{
    [Verb("up", HelpText = "Update database.")]
    public class UpOptions
    {
        [Option(Default = null, Required = false, HelpText = "Update up to specified migration number(included)")]
        public int? UpTo { get; set; }
    }
}