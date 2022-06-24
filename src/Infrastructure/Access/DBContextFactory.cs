using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Web1.Infrastructure
{
    public class MigrationContextFactory : IDesignTimeDbContextFactory<MigrationDbContext>
    {
        public MigrationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MigrationDbContext>();

            // получаем конфигурацию из файла appsettings.json
            ConfigurationBuilder builder = new ConfigurationBuilder();
            string patch = Directory.GetCurrentDirectory();
            builder.SetBasePath(patch.Remove(patch.Length - 11, 11) + "Application");
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            // получаем строку подключения из файла appsettings.json
            string connectionString;
            switch (config["DbType"])
            {
                case "SQLite":
                    connectionString = config.GetConnectionString("SQLite");
                    optionsBuilder.UseSqlite(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
                    break;
                case "PostgreSQL":
                    connectionString = config.GetConnectionString("PostgreSQL");
                    optionsBuilder.UseNpgsql(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
                    break;
                case "SQL Server":
                    connectionString = config.GetConnectionString("SQL Server");
                    optionsBuilder.UseSqlServer(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
                    break;
                default:
                    throw new Exception($"Неверный поставщик базы данных {config["DbType"]}");
            }
            return new MigrationDbContext(optionsBuilder.Options);
        }
    }
}