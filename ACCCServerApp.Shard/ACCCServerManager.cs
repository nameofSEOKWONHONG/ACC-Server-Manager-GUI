﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ACCCServerApp.Shard.Models;
using FluentValidation;
using Newtonsoft.Json;

namespace ACCCServerApp.Shard
{
    //accc server wiki : https://www.acc-wiki.info/wiki/Server_Configuration



    public class ACCCServerManager : IACCCServerManager
    {
        public ACCCServerConfig ACServerConfig { get; private set; }
        public string ServerName { get; set; }
        private Dictionary<string, string> _keyValues = new Dictionary<string, string>()
        {
            {"Configuration", "cfg/configuration.json" },
            {"Event", "cfg/event.json" },
            {"Settings", "cfg/settings.json" },
            {"AssistRules", "cfg/assistRules.json" }
        };
        private ProcessHandler _processHandler;

        public ACCCServerManager(ACCCServerConfig aCCCServerConfig)
        {
            this.ACServerConfig = aCCCServerConfig;
            ServerName = this.ACServerConfig.Settings.ServerName;

            var configurationJson = File.ReadAllText(Path.Combine("./containers/" + this.ACServerConfig.Settings.ServerName, _keyValues.Where(m => m.Key == nameof(ACServerConfig.Configuration)).First().Value));
            var eventJson = File.ReadAllText(Path.Combine("./containers/" + this.ACServerConfig.Settings.ServerName, _keyValues.Where(m => m.Key == nameof(ACServerConfig.Event)).First().Value));
            var settingsJson = File.ReadAllText(Path.Combine("./containers/" + this.ACServerConfig.Settings.ServerName, _keyValues.Where(m => m.Key == nameof(ACServerConfig.Settings)).First().Value));
            var assisRulesJson = File.ReadAllText(Path.Combine("./containers/" + this.ACServerConfig.Settings.ServerName, _keyValues.Where(m => m.Key == nameof(ACServerConfig.AssistRules)).First().Value));

            if(ACServerConfig.Configuration == null)
            {
                ACServerConfig.Configuration = JsonConvert.DeserializeObject<Configuration>(configurationJson);
            }

            if(ACServerConfig.Event == null)
            {
                ACServerConfig.Event = JsonConvert.DeserializeObject<Event>(eventJson);
            }

            //if(ACServerConfig.Settings == null)
            //{
                ACServerConfig.Settings = JsonConvert.DeserializeObject<Settings>(settingsJson);
            //}

            ACServerConfig.AssistRules = JsonConvert.DeserializeObject<AssistRules>(assisRulesJson);

            _processHandler = new ProcessHandler();
        }

        public ACCCServerResult Start()
        {
            var serverResult = new ACCCServerResult();
            var validator = new ACCCServerManagerValidator();
            var results = validator.Validate(this);

            try
            {
                serverResult.HasError = !results.IsValid;
                if (!results.IsValid)
                {
                    serverResult.Message = results.Errors.First().ErrorMessage;
                }

                var path1 = Path.GetFullPath($"./containers/{ServerName}/cmd.exe");
                var path = Path.GetFullPath($"./containers/{ServerName}/accServer.exe");

                _processHandler.CreateProcess(path, "", $"./containers/{ServerName}",
                    (output) =>
                    {
                        Console.WriteLine(output);
                    },
                    (error) =>
                    {
                        Console.WriteLine(error);
                    }).Run();
            }
            catch (Exception e)
            {
                serverResult.HasError = false;
            }

            return serverResult;
        }

        public ACCCServerResult Stop()
        {
            var serverResult = new ACCCServerResult();
            try
            {
                _processHandler.Stop();
            }
            catch(Exception e)
            {
                serverResult.HasError = true;
                serverResult.Message = e.Message;
            }

            return serverResult;
        }

        public class ACCCServerManagerValidator : AbstractValidator<ACCCServerManager>
        {
            public ACCCServerManagerValidator()
            {
                SettingsValidator();
            }

            private bool SettingsValidator()
            {
                //RuleFor(m => m.ACServerConfig.Settings.AdminPassword).NotEmpty();
                //RuleFor(m => m.ACServerConfig.Settings.Password).NotEmpty();
                //RuleFor(m => m.ACServerConfig.Settings.ServerName).NotEmpty();
                //RuleFor(m => m.ACServerConfig.Settings.ConfigVersion).LessThan(0);
                //RuleFor(m => m.ACServerConfig.Settings.SpectatorPassword).NotEmpty();

                //RuleFor(m => m.ACServerConfig.Settings.Password).NotEqual(m => m.ACServerConfig.Settings.AdminPassword);

                return true;
            }
        }
    }
}
