using CommandLine;

namespace FluentMigratorDemo.Options
{
    [Verb("check", isDefault: true, aliases: new string[] { "ValidateVersionOrder" }, HelpText = "Validate version order.")]
    public class CheckOptions
    {
    }
}