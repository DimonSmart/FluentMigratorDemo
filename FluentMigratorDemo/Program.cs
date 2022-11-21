using CommandLine;
using FluentMigrator.Runner;
using FluentMigratorDemo.Migrations;
using FluentMigratorDemo.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static FluentMigratorDemo.MigratorRunner;

namespace FluentMigratorDemo
{
    class Program
    {
        static int Main(string[] args)
        {
            var connectionString = GetConnectionString("TargetDbConnection");
            var serviceProvider = CreateServices(connectionString);
            using var scope = serviceProvider.CreateScope();
            return Parser.Default.ParseArguments
                <CheckOptions, UpOptions, DownOptions>(args)
            .MapResult(
            (CheckOptions opts) => CheckDatabase(scope.ServiceProvider, opts),
            (UpOptions opts) => UpDatabase(scope.ServiceProvider, opts),
            (DownOptions opts) => DownDatabase(scope.ServiceProvider, opts),
            errs => 1);
        }

        private static IServiceProvider CreateServices(string connectionString)
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                     .AddSqlServer()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(M00000_InitialMigration).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        public static string GetConnectionString(string sectionName)
        {
            var environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddUserSecrets<Program>();
            var configurationRoot = builder.Build()!;
            var connectionString = configurationRoot.GetConnectionString(sectionName);
            if (connectionString is null)
            {
                throw new Exception("Please specify connection string in appsettings.json or local secrets.json");
            }
            return connectionString;
        }
    }
}