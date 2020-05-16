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
        private readonly ACCServerConfig _config;
        private readonly Dictionary<string, string> _keyValues = new Dictionary<string, string>()
        {
            {"Configuration", "cfg/configuration.json" },
            {"Event", "cfg/event.json" },
            {"Settings", "cfg/settings.json" },
            {"AssistRules", "cfg/assistRules.json" }
        };

        public ACCServerFileManager(ACCServerConfig config)
        {
            this._config = config;
        }

        #region [Save & Load]
        public void ConfigSave(DirectoryInfo dirInfo)
        {
            if (_config.Configuration.jIsNull()) throw new Exception("configuration is null");
            if (_config.Event.jIsNull()) throw new Exception("event is null");
            if (_config.Settings.jIsNull()) throw new Exception("settings is null");

            JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            var configuration = JsonConvert.SerializeObject(_config.Configuration, Formatting.Indented, jsSettings);
            var @event = JsonConvert.SerializeObject(_config.Event, Formatting.Indented, jsSettings);
            var settings = JsonConvert.SerializeObject(_config.Settings, Formatting.Indented, jsSettings);

            var savePath = Path.Combine("./containers/" + _config.Settings.ServerName);

            var configurationFilePath = dirInfo.FullName + "/cfg/configuration.json";
            if (File.Exists(configurationFilePath))
            {
                File.Delete(configurationFilePath);
                
            }
            File.WriteAllText(configurationFilePath, configuration, System.Text.Encoding.UTF8);

            var eventFilePath = dirInfo.FullName + "/cfg/event.json";
            if (File.Exists(eventFilePath))
            {
                File.Delete(eventFilePath);
                
            }
            File.WriteAllText(eventFilePath, @event, System.Text.Encoding.UTF8);

            var settingsFilePath = dirInfo.FullName + "/cfg/settings.json";
            if (File.Exists(settingsFilePath))
            {
                File.Delete(settingsFilePath);
                
            }
            File.WriteAllText(settingsFilePath, settings, System.Text.Encoding.UTF8);
        }

        public ACCServerConfig ConfigLoad()
        {
            var accServerConfig = new ACCServerConfig();

            var configurationJson = File.ReadAllText(Path.Combine("./containers/" + this._config.Settings.ServerName, _keyValues.Where(m => m.Key == nameof(_config.Configuration)).First().Value));
            var eventJson = File.ReadAllText(Path.Combine("./containers/" + this._config.Settings.ServerName, _keyValues.Where(m => m.Key == nameof(_config.Event)).First().Value));
            var settingsJson = File.ReadAllText(Path.Combine("./containers/" + this._config.Settings.ServerName, _keyValues.Where(m => m.Key == nameof(_config.Settings)).First().Value));
            var assisRulesJson = File.ReadAllText(Path.Combine("./containers/" + this._config.Settings.ServerName, _keyValues.Where(m => m.Key == nameof(_config.AssistRules)).First().Value));

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

            if (accServerConfig.AssistRules.jIsNotNull())
            {
                accServerConfig.AssistRules = JsonConvert.DeserializeObject<AssistRules>(assisRulesJson);
            }

            return accServerConfig;
        }
        #endregion
    }
}
