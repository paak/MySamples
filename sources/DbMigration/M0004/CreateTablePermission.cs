namespace DbMigration.M0004
{
    [FluentMigrator.Migration(4, "Create Table _Permission")]
    public class CreateTablePermission : DbMigrationBase
    {
        public override void Up()
        {
            Create.Table("_Permission")
                .WithColumn("Id")
                    .AsInt16()
                    .Identity()
                    .PrimaryKey("PK_Permission")
                .WithColumn("Code")
                    .AsAnsiString(16)
                    .Indexed("UI_Permission_Code")
                    .NotNullable()
                .WithColumn("Name")
                    .AsAnsiString(64)
                    .Nullable();

            Insert.IntoTable("_Permission")
                .Row(new { Code = "root", Name = "Root" })
                .Row(new { Code = "admin", Name = "Administrator" })
                .Row(new { Code = "user", Name = "User" })
                .Row(new { Code = "sales", Name = "Sales person" });

            base.Up();
        }

        public override void Down()
        {
            DropTable("_Permission");

            base.Down();
        }
    }
}
