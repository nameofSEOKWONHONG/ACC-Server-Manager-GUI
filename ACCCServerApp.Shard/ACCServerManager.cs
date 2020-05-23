﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ACCServerApp.Shard.Models;
using FluentValidation;
using JDotnetExtension;
using Newtonsoft.Json;

namespace ACCServerApp.Shard
{
    //accc server wiki : https://www.acc-wiki.info/wiki/Server_Configuration

    /// <summary>
    /// ACCC SERVER MANAGER CLASS
    /// </summary>
    public class ACCServerManager : IACCServerManager
    {
        public ACCServerConfig ACServerConfig { get; private set; }
        public string ServerName { get; set; }

        /// <summary>
        /// JSON FILE LIST
        /// </summary>
        private Dictionary<string, string> _keyValues = new Dictionary<string, string>()
        {
            {"Configuration", "cfg/configuration.json" },
            {"Event", "cfg/event.json" },
            {"Settings", "cfg/settings.json" },
            {"AssistRules", "cfg/assistRules.json" }
        };

        #region [constructor]
        public ACCServerManager(ACCServerConfig aCCCServerConfig)
        {
            this.ACServerConfig = aCCCServerConfig;
            this.ServerName = this.ACServerConfig.Settings.ServerName;
        }
        #endregion

        #region [Start & Stop]
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
                    throw new Exception(serverResult.Message);
                }

                var path1 = Path.GetFullPath($"./containers/{ServerName}/cmd.exe");
                var path = Path.GetFullPath($"./containers/{ServerName}/accServer.exe");

                var procHandler = new ProcessSimpleHandler();
                procHandler.Run(path, "", $"./containers/{ServerName}");
            }
            catch (Exception e)
            {
                serverResult.HasError = true;
                serverResult.Message = e.Message;
            }

            return serverResult;
        }

        public ACCCServerResult Stop()
        {
            var serverResult = new ACCCServerResult();
            try
            {
                var procHandler = new ProcessSimpleHandler();
                procHandler.Stop();
            }
            catch(Exception e)
            {
                serverResult.HasError = true;
                serverResult.Message = e.Message;
            }

            return serverResult;
        }
        #endregion

        

        #region [Validator]
        public class ACCCServerManagerValidator : AbstractValidator<ACCServerManager>
        {
            public ACCCServerManagerValidator()
            {
                RuleFor(m => m.ACServerConfig.Settings.AdminPassword).NotEmpty();
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
        #endregion
    }
}
