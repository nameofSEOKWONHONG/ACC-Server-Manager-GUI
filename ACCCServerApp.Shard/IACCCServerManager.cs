using ACCCServerApp.Shard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCCServerApp.Shard
{
    public interface IACCCServerManager
    {
        ACCCServerResult Start();
        ACCCServerResult Stop();
    }
}
