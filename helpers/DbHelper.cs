using System;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

public class DbHelper
{
    public IConfigurationRoot Configuration { get; set;}
    private string DatabaseName { get; set; }
    public DbHelper(string databaseName, IConfigurationRoot configuration)
    {
        DatabaseName = databaseName;
        Configuration = configuration;
    }
    public DbConnection Initialize()
    {
        string connectionString = GetConnectionStringFromAppSettings(DatabaseName);
        return new MySqlConnection(connectionString);
    }

    private string GetConnectionStringFromAppSettings(string dbName)
    {
        return ConfigurationExtensions.GetConnectionString(this.Configuration, dbName);
    }
}