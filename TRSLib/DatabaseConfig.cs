using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace TRSLib
{
    public class DatabaseConfig
    {
        public DatabaseConfig()
        {
            IConfiguration Config = new ConfigurationBuilder()
               .AddJsonFile("appSettings.json")
               .Build();
            this.Name = Config.GetSection("DatabaseName").Value;
        }
        public string Name { get; set; }      
            
        
    }
}
