namespace DbMigration.M0006
{
    [FluentMigrator.Migration(6, "Create Table Company_AKA")]
    public class CreateTableCompanyAKA : DbMigrationBase
    {
        public override void Up()
        {
            Create.Table("Company_AKA")
                .WithColumn("CompanyId")
                    .AsInt32()
                    .PrimaryKey("PK_Company_AKA")
                    .ForeignKey("FK_Company_AKA_Id", "Company", "Id")
                .WithColumn("Name")
                    .AsAnsiString(128)
                    .NotNullable();

            base.Up();
        }

        public override void Down()
        {
            DropTable("Company_AKA");

            base.Down();
        }
    }
}
