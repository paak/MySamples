using FluentMigrator;

namespace DbMigration
{
    /// <summary>
    /// BaseMigration
    /// </summary>
    public class DbMigrationBase : Migration
    {
        /// <summary>
        /// "WINConnectT"
        /// </summary>
        protected const string SchemaName = "WINConnectT";

        /// <summary>
        /// Down
        /// </summary>
        public override void Down()
        {
        }

        /// <summary>
        /// Up
        /// </summary>
        public override void Up()
        {
        }

        /// <summary>
        /// Drop Column with check exists column
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        protected virtual void DropColumn(string tableName, string columnName)
        {
            if (Schema.Table(tableName).Column(columnName).Exists())
            {
                Delete.Column(columnName).FromTable(tableName);
            }
        }

        /// <summary>
        /// DropTable
        /// </summary>
        /// <param name="tableName"></param>
        protected virtual void DropTable(string tableName)
        {
            if (Schema.Table(tableName).Exists())
            {
                Delete.Table(tableName);
            }
        }

        /// <summary>
        /// Exists Colum
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        protected virtual bool ExistsColum(string tableName, string columnName)
        {
            return Schema.Table(tableName).Column(columnName).Exists();
        }

        /// <summary>
        /// Reseed Identity column to maximum
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        protected virtual void ReseedIdentity(string tableName, string columnName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(columnName))
            {
                return;
            }

            string sql = "DECLARE @maxVal INT; " +
                "SELECT @maxVal = ISNULL(MAX({1}), 0) FROM {0}; " +
                "DBCC CHECKIDENT('{0}', RESEED, @maxVal); ";

            Execute.Sql(string.Format(sql, tableName, columnName));
        }
    }
}
