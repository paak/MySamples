namespace DbMigration.M0002
{
    [FluentMigrator.Migration(2, "Create Table _City")]
    public class CreateTableCity : DbMigrationBase
    {
        public override void Up()
        {
            Create.Table("_City")
                .WithColumn("Code")
                    .AsAnsiString(5)
                    .Unique("IX_City_Code")
                    .PrimaryKey("PK_City")
                .WithColumn("CountryCode")
                    .AsAnsiString(2)
                    .NotNullable()
                    .ForeignKey("FK_City_Country", "_Country", "Code")
                .WithColumn("Name")
                    .AsAnsiString(256)
                    .NotNullable();

            Insert.IntoTable("_City")
                .Row(new { Code = "USMIA", CountryCode = "US", Name = "FL - Miami" })
                .Row(new { Code = "CNSGH", CountryCode = "CN", Name = "Shanghai" })
                .Row(new { Code = "THBKK", CountryCode = "TH", Name = "Krung Thep Mahanakhon" })
                .Row(new { Code = "GBLND", CountryCode = "GB", Name = "London, City of" });

            base.Up();
        }

        public override void Down()
        {
            DropTable("_City");

            base.Down();
        }
    }
}
