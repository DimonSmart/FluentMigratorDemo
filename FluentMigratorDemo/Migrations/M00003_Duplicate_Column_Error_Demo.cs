using FluentMigrator;

namespace FluentMigratorDemo.Migrations
{
    [Migration(3, "Duplicate column creation demo")]
    public class M00003_Duplicate_Column_Error_Demo :
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
