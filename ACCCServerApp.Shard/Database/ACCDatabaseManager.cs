using ACCServerApp.Shard.Models;
using AutoMapper;
using JDotnetExtension;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ACCServerApp.Shard
{
    public class ACCDatabaseManager
    {
        private static string _dbPath = Path.Combine("./db", "/acc_config.db");
        
        public ACCDatabaseManager()
        {
            if (!Directory.Exists(_dbPath))
            {
                Directory.CreateDirectory(_dbPath);
            }
        }

        public bool AddConfig(ACCServerConfig config)
        {
            using(var db = new LiteDatabase(_dbPath))
            {
                var col = db.GetCollection<ACCServerConfig>("accServerConfig");
                var result = col.Insert(config);
                col.EnsureIndex(x => x.Settings.ServerName);
            }

            return true;
        }

        public ACCServerConfig GetConfig(string serverName)
        {
            using (var db = new LiteDatabase(_dbPath))
            {
                var col = db.GetCollection<ACCServerConfig>("accServerConfig");
                return col.Query().Where(x => x.Settings.ServerName == serverName).FirstOrDefault();
            }
        }

        public IEnumerable<ACCServerConfig> GetConfigs()
        {
            using(var db = new LiteDatabase(_dbPath))
            {
                var col = db.GetCollection<ACCServerConfig>("accServerConfig");
                return col.Query().ToEnumerable();
            }
        }
    }
}
