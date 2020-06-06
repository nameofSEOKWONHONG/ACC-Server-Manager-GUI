using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACCServerApp.Shard.Models
{
    public class Configuration
    {
        [JsonProperty("udpPort")]
        public int UDPPort { get; set; } = 9231; //default

        [JsonProperty("tcpPort")]
        public int TCPPort { get; set; } = 9232; //default

        [JsonProperty("maxConnections")]
        public int MaxConnection { get; set; } = 85; //default

        [JsonProperty("registerToLobby")]
        public int RegisterToLobby { get; set; } = 1;


        [JsonProperty("configVersion")]
        public int ConfigVersion { get; set; } = 1; //default

        public class Validator : AbstractValidator<Configuration>
        {
            public Validator()
            {
                RuleFor(m => m.UDPPort).GreaterThan(0).NotEqual(80).NotEqual(8080);
                RuleFor(m => m.TCPPort).GreaterThan(0).NotEqual(80).NotEqual(8080);
                RuleFor(m => m.MaxConnection).GreaterThan(0).LessThan(100);
            }
        }
    }

}
