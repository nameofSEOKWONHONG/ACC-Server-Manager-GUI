using System;
using System.Collections.Generic;
using System.Text;

namespace ACCCServerApp.Shard.Models
{
    public class Configuration
    {
        public int UdpPort { get; set; } = 9231; //default
        public int TcpPort { get; set; } = 9232; //default
        public int MaxConnection { get; set; } = 85; //default
        public int ConfigVersion { get; set; } = 1; //default
    }

}
