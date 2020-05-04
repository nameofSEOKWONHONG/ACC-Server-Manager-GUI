using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACCCServerApp.Shard.Models
{
    public class ACCCServerConfig
    {
        public Configuration Configuration { get; set; }
        public Event Event { get; set; }
        public Settings Settings { get; set; }
        public AssistRules AssistRules { get; set; }

        public class Validator : AbstractValidator<ACCCServerConfig>
        {
            public Validator()
            {
                RuleFor(m => m.Configuration).NotNull();
                RuleFor(m => m.Event).NotNull();
                RuleFor(m => m.Settings).NotNull();
            }
        }

    }


}
