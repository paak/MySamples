namespace DbMigration.M0005
{
    [FluentMigrator.Migration(5, "Create Table Company")]
    public class CreateTableCompany : DbMigrationBase
    {
        public override void Up()
        {
            Create.Table("Company")
                .WithColumn("Id")
                    .AsInt32()
                    .Identity()
                    .PrimaryKey("PK_Company")
                .WithColumn("Name")
                    .AsString(256)
                    .NotNullable()
                .WithColumn("CityCode")
                    .AsAnsiString(5)
                    .NotNullable()
                    .ForeignKey("FK_Company_City", "_City", "Code")
                .WithColumn("CountryCode")
                    .AsAnsiString(2)
                    .NotNullable()
                    .ForeignKey("FK_Company_Country", "_Country", "code")
                .WithColumn("IsMember")
                    .AsBoolean()
                    .NotNullable()
                    .WithDefaultValue(0)
                .WithColumn("CreatedOn")
                    .AsDateTime()
                    .NotNullable()
                    .WithDefaultValue(FluentMigrator.SystemMethods.CurrentDateTime)
                .WithColumn("CreatedBy")
                    .AsInt16()
                    .Nullable()
                .WithColumn("UpdatedOn")
                    .AsDateTime()
                    .NotNullable()
                    .WithDefaultValue(FluentMigrator.SystemMethods.CurrentDateTime)
                .WithColumn("UpdatedBy")
                    .AsInt16()
                    .Nullable();

            InsertCompany();

            base.Up();
        }

        public override void Down()
        {
            DropTable("Company");

            base.Down();
        }

        private void InsertCompany()
        {
            Insert.IntoTable("Company")
                .Row(new { Name = "ABC Freight", CityCode = "USMIA", CountryCode = "US", IsMember = 1 })
                .Row(new { Name = "ABC Freight - Non Member", CityCode = "USMIA", CountryCode = "US", IsMember = 0 })
                .Row(new { Name = "ABC Forwarder", CityCode = "THBKK", CountryCode = "TH", IsMember = 1 })
                .Row(new { Name = "ABC Forwarder - Non Member", CityCode = "THBKK", CountryCode = "TH", IsMember = 0 })
                .Row(new { Name = "ABC Transport", CityCode = "CNSGH", CountryCode = "CN", IsMember = 1 })
                .Row(new { Name = "ABC Transport - Non Member", CityCode = "CNSGH", CountryCode = "CN", IsMember = 0 })
                .Row(new { Name = "ABC Mover", CityCode = "GBLND", CountryCode = "GB", IsMember = 1 })
                .Row(new { Name = "ABC Mover - Non Member", CityCode = "GBLND", CountryCode = "GB", IsMember = 0 });
        }
    }
}
