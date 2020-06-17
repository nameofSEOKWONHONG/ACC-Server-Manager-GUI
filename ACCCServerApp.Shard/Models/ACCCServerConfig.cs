using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACCServerApp.Shard.Models
{
    public class ACCServerConfig
    {
        public Configuration Configuration { get; set; }
        public Event Event { get; set; }
        public Settings Settings { get; set; }
        public AssistRules AssistRules { get; set; }

        public string ServerFilePath { get; set; }

        public class Validator : AbstractValidator<ACCServerConfig>
        {
            public Validator()
            {
                RuleFor(m => m.Configuration).NotNull();
                RuleFor(m => m.Event).NotNull();
                RuleFor(m => m.Settings).NotNull();
                RuleFor(m => m.ServerFilePath).NotEmpty();
            }
        }

    }


}
