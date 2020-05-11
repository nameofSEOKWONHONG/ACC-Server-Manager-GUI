using ACCServerApp.Shard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCServerApp.Shard
{
    public interface IACCServerManager
    {
        ACCCServerResult Start();
        ACCCServerResult Stop();
    }
}
