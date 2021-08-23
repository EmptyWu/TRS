﻿using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace TRSLib
{
    public interface IDatabaseBootstrap
    {
        void Setup();
    }
    public class DataBase : IDatabaseBootstrap
    {
        private readonly DatabaseConfig databaseConfig;

        public DataBase(DatabaseConfig databaseConfig)
        {
           this.databaseConfig = databaseConfig;
        }
        public void Setup()
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'Product';");
            var tableName = table.FirstOrDefault();
            if (!string.IsNullOrEmpty(tableName) && tableName == "Product")
                return;

            connection.Execute("Create Table Product (" +
                "Name VARCHAR(100) NOT NULL," +
                "Description VARCHAR(1000) NULL);");
        }
    }
}
