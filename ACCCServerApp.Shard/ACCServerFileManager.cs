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
        public void ConfigSave()
        {
            if (_config.Configuration.jIsNull()) throw new Exception("configuration is null");
            {

            }
            var configuration = JsonConvert.SerializeObject(_config.Configuration, Formatting.Indented);
            var savePath = Path.Combine("./containers/" + _config.Settings.ServerName);
            File.WriteAllText(savePath + "/configuration.json", configuration, System.Text.Encoding.UTF8);
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
