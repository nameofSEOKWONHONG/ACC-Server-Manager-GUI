using System;
using System.Collections.Generic;
using System.Text;

namespace ACCCServerApp.Shard.Models
{
    public class ACCCServerResult
    {
        public bool HasError { get; set; } = false;
        public string Message { get; set; }
    }
}
