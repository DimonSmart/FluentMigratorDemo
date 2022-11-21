using FluentMigrator;

namespace FluentMigratorDemo.Migrations
{
    [Migration(1, "Log table added")]
    public class M00001_AddLogTable : Migration
    {
        public override void Up()
        {
            Create.Table("Log")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Message").AsString();
        }

        public override void Down()
        {
            Delete.Table("Log");
        }
    }
}
