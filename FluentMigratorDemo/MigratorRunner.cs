using FluentMigrator.Runner;
using FluentMigratorDemo.Options;
using Microsoft.Extensions.DependencyInjection;

namespace FluentMigratorDemo
{
    public static class MigratorRunner
    {
        public static int CheckDatabase(IServiceProvider serviceProvider, CheckOptions opts)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            return TryRun(runner.ValidateVersionOrder);

        }
        public static int UpDatabase(IServiceProvider serviceProvider, UpOptions opts)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            if (opts.UpTo.HasValue)
            {
                return TryRun(() => runner.MigrateUp(opts.UpTo.Value));
            }
            return TryRun(runner.MigrateUp);
        }
        public static int DownDatabase(IServiceProvider serviceProvider, DownOptions opts)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            return TryRun(() => runner.MigrateDown(opts.DownTo));
        }

        private static int TryRun(Action action)
        {
            try
            {
                action();
                return RunStatus.Ok;
            }
            catch (Exception)
            {
                return RunStatus.Error;
            }
        }
    }
}