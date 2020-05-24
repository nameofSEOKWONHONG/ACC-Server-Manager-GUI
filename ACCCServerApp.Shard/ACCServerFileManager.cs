using ACCServerApp.Shard.Models;
using JDotnetExtension;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ACCServerApp.Shard
{
    public class ACCServerFileManager
    {
        private readonly Dictionary<string, string> _keyValues = new Dictionary<string, string>()
        {
            {"Configuration", "configuration.json" },
            {"Event", "event.json" },
            {"Settings", "settings.json" },
            {"AssistRules", "assistRules.json" }
        };

        public ACCServerFileManager()
        {
        }

        #region [Save & Load]
        public void ConfigSave(ACCServerConfig config, DirectoryInfo dirInfo)
        {
            if (config.jIsNull()) throw new Exception("config is null");
            if (config.Configuration.jIsNull()) throw new Exception("configuration is null");
            if (config.Event.jIsNull()) throw new Exception("event is null");
            if (config.Settings.jIsNull()) throw new Exception("settings is null");

            JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            var configuration = JsonConvert.SerializeObject(config.Configuration, Formatting.Indented, jsSettings);
            var @event = JsonConvert.SerializeObject(config.Event, Formatting.Indented, jsSettings);
            var settings = JsonConvert.SerializeObject(config.Settings, Formatting.Indented, jsSettings);

            var savePath = Path.Combine("./containers/" + config.Settings.ServerName);

            var configurationFilePath = dirInfo.FullName + "/cfg/configuration.json";
            if (!Directory.Exists(dirInfo.FullName + "/cfg"))
            {
                Directory.CreateDirectory(dirInfo.FullName + "/cfg");
            }
            if (File.Exists(configurationFilePath))
            {
                File.Delete(configurationFilePath);                
            }
            File.WriteAllText(configurationFilePath, configuration, Encoding.Unicode);

            var eventFilePath = dirInfo.FullName + "/cfg/event.json";
            if (File.Exists(eventFilePath))
            {
                File.Delete(eventFilePath);                
            }
            File.WriteAllText(eventFilePath, @event, System.Text.Encoding.Unicode);

            var settingsFilePath = dirInfo.FullName + "/cfg/settings.json";
            if (File.Exists(settingsFilePath))
            {
                File.Delete(settingsFilePath);
            }
            File.WriteAllText(settingsFilePath, settings, Encoding.Unicode);
        }

        public ACCServerConfig ConfigLoad(string configPath)
        {
            var accServerConfig = new ACCServerConfig();

            var configurationJson = File.ReadAllText(Path.Combine(configPath, _keyValues.Where(m => m.Key == nameof(accServerConfig.Configuration)).First().Value));
            var eventJson = File.ReadAllText(Path.Combine(configPath, _keyValues.Where(m => m.Key == nameof(accServerConfig.Event)).First().Value));
            var settingsJson = File.ReadAllText(Path.Combine(configPath, _keyValues.Where(m => m.Key == nameof(accServerConfig.Settings)).First().Value));
            //var assisRulesJson = File.ReadAllText(Path.Combine(configPath, _keyValues.Where(m => m.Key == nameof(_config.AssistRules)).First().Value));

            if (accServerConfig.Configuration == null)
            {
                accServerConfig.Configuration = JsonConvert.DeserializeObject<Configuration>(configurationJson);
            }

            if (accServerConfig.Event == null)
            {
                accServerConfig.Event = JsonConvert.DeserializeObject<Event>(eventJson);
            }

            if (accServerConfig.Settings == null)
            {
                accServerConfig.Settings = JsonConvert.DeserializeObject<Settings>(settingsJson);
            }

            //if (accServerConfig.AssistRules.jIsNotNull())
            //{
            //    accServerConfig.AssistRules = JsonConvert.DeserializeObject<AssistRules>(assisRulesJson);
            //}

            return accServerConfig;
        }
        #endregion
    }
}
