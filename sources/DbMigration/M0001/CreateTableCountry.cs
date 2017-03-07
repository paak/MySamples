namespace DbMigration.M0001
{
    [FluentMigrator.Migration(1, "Create Table _Country")]
    public class CreateTableCountry : DbMigrationBase
    {
        public override void Up()
        {
            Create.Table("_Country")
                .WithColumn("Code")
                    .AsAnsiString(2)
                    .Unique("IX_Country_Code")
                    .PrimaryKey("PK_Country")
                .WithColumn("Name")
                    .AsAnsiString(256)
                    .NotNullable()
                    .Indexed("UI_Country_Name");

            Insert.IntoTable("_Country")
                .Row(new { Code = "US", Name = "United States of America" })
                .Row(new { Code = "TH", Name = "Thailand" })
                .Row(new { Code = "CN", Name = "China" })
                .Row(new { Code = "GB", Name = "United Kingdom" });

            base.Up();
        }

        public override void Down()
        {
            DropTable("_Country");

            base.Down();
        }
    }
}
