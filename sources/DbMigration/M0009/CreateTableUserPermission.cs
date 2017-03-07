using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigration.M0009
{
    [FluentMigrator.Migration(9, "Create Table User_Permission")]
    public class CreateTableUserPermission : DbMigrationBase
    {
        public override void Up()
        {
            Create.Table("User_Permission")
                .WithColumn("UserId")
                    .AsInt32()
                    .NotNullable()
                    .ForeignKey("FK_User_Permission_User", "User", "Id")
                .WithColumn("PermissionId")
                    .AsInt16()
                    .NotNullable()
                    .ForeignKey("FK_User_Permission_Permission", "_Permission", "Id");

            Create.UniqueConstraint("IX_User_Permission")
                .OnTable("User_Permission")
                .Columns(new string[] { "UserId", "PermissionId" });

            base.Up();
        }

        public override void Down()
        {
            DropTable("User_Permission");

            base.Down();
        }
    }
}
