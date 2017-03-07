namespace DbMigration.M0007
{
    [FluentMigrator.Migration(7, "Create Table Company_Network")]
    public class CreateTableCompanyNetwork : DbMigrationBase
    {
        public override void Up()
        {
            Create.Table("Company_Network")
                .WithColumn("CompanyId")
                    .AsInt32()
                    .NotNullable()
                    .ForeignKey("FK_Company_Network_Company", "Company", "Id")
                .WithColumn("NetworkId")
                    .AsInt16()
                    .NotNullable()
                    .ForeignKey("FK_Company_Network_Network", "_Network", "id");

            Create.UniqueConstraint("IX_Company_Network")
                .OnTable("Company_Network")
                .Columns(new string[] { "CompanyId", "NetworkId" });

            base.Up();
        }

        public override void Down()
        {
            DropTable("Company_Network");

            base.Down();
        }
    }
}
