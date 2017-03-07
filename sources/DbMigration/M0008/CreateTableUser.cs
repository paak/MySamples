namespace DbMigration.M0008
{
    [FluentMigrator.Migration(8, "Create Table User")]
    public class CreateTableUser : DbMigrationBase
    {
        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id")
                    .AsInt32()
                    .Identity()
                    .PrimaryKey()
                .WithColumn("Username")
                    .AsAnsiString(128)
                    .Unique()
                    .NotNullable()
                .WithColumn("Name")
                    .AsAnsiString(128)
                    .NotNullable();

            base.Up();
        }

        public override void Down()
        {
            DropTable("User");

            base.Down();
        }

        private void InsertUser()
        {
            Insert.IntoTable("User")
                .Row(new { Username = "O", Name = "O" })
                .Row(new { Username = "Fon", Name = "Fon" })
                .Row(new { Username = "Nooz", Name = "Nooz" })
                .Row(new { Username = "Jeab", Name = "Jeab" })
                .Row(new { Username = "Paak", Name = "Paak" })
                .Row(new { Username = "Suda", Name = "Suda" })
                .Row(new { Username = "Puth", Name = "Puth" })
                .Row(new { Username = "Puy", Name = "Puy" })
                .Row(new { Username = "Pam", Name = "Pam" })
                .Row(new { Username = "Non", Name = "Non" });
        }
    }
}
