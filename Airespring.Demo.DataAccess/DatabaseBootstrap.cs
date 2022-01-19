using Airespring.Demo.DataAccess.Interfaces;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Airespring.Demo.DataAccess
{
    public class DatabaseBootstrap : IDatabaseBootstrap
    {
        private readonly DatabaseConfig databaseConfig;

        public DatabaseBootstrap(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public void Setup()
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'Employee';");
            var tableName = table.FirstOrDefault();
            if (!string.IsNullOrEmpty(tableName) && tableName == "Employee")
                return;

            connection.Execute("Create Table Employee (" +
                "ID VARCHAR(36) NOT NULL," +
                "LastName VARCHAR(1000) NULL, " +
                "FirstName VARCHAR(1000) NULL, " +
                "Phone VARCHAR(14) NULL, " +
                "Zip VARCHAR(16) NULL, " +
                "HireDate VARCHAR(10) NULL);");
        }
    }
}
