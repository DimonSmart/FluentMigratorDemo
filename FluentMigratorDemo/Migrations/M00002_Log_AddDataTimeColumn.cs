using FluentMigrator;

namespace FluentMigratorDemo.Migrations
{
    [Migration(2, "Log table record creation time column added")]
    public class M00002_Log_AddDataTimeColumn :
        AutoReversingMigration
    {
        public override void Up()
        {
            Create
                .Column("Created")
                .OnTable("Log")
                .AsDateTime()
                .NotNullable()
                .WithDefault(SystemMethods.CurrentDateTime);
        }
    }
}
