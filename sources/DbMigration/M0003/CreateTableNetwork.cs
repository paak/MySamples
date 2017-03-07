namespace DbMigration.M0003
{
    [FluentMigrator.Migration(3, "Create Table _Network")]
    public class CreateTableNetwork : DbMigrationBase
    {
        public override void Up()
        {
            Create.Table("_Network")
                .WithColumn("Id")
                    .AsInt16()
                    .Identity()
                    .PrimaryKey("PK_Network")
                    .Indexed("IX_Network_Id")
                .WithColumn("Code")
                    .AsAnsiString(16)
                    .Unique("IX_Network_Code")
                    .NotNullable()
                .WithColumn("Name")
                    .AsAnsiString(128)
                    .NotNullable()
                    .Indexed("IX_Network_Name")
                .WithColumn("TypeID")
                    .AsInt16()
                    .NotNullable()
                    .WithDefaultValue(1);

            Insert.IntoTable("_Network")
                .Row(new { Code = "WCA", Name = "WCA First" })
                .Row(new { Code = "APLN", Name = "WCA Advanced Professionals" })
                .Row(new { Code = "CGLN", Name = "WCA China Global" })
                .Row(new { Code = "IGLN", Name = "WCA Inter Global" })
                .Row(new { Code = "WCAPN", Name = "All World Shipping" })
                .Row(new { Code = "AWS", Name = "WCA First", TypeID = 2 });

            base.Up();
        }

        public override void Down()
        {
            DropTable("_Network");

            base.Down();
        }
    }
}
