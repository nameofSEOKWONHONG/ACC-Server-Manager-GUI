using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACCCServerApp.Shard.Models
{
    public class Configuration
    {
        public int UDPPort { get; set; } = 9231; //default
        public int TCPProt { get; set; } = 9232; //default
        public int MaxConnection { get; set; } = 85; //default
        public int ConfigVersion { get; set; } = 1; //default

        public class Validator : AbstractValidator<Configuration>
        {
            public Validator()
            {
                RuleFor(m => m.UDPPort).GreaterThan(0).NotEqual(80).NotEqual(8080);
                RuleFor(m => m.TCPProt).GreaterThan(0).NotEqual(80).NotEqual(8080);
                RuleFor(m => m.MaxConnection).GreaterThan(0).LessThan(100);
            }
        }
    }

}
