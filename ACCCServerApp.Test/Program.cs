using ACCCServerApp.Shard;
using ACCCServerApp.Shard.Utils;
using System;
using System.Diagnostics;

namespace ACCCServerApp.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProcessHandler.Instance.CreateProcess("ping.exe",
            //    "www.google.com -t",
            //    (output) =>
            //    {
            //        Console.WriteLine(output);
            //    },
            //    (error) =>
            //    {
            //        Console.WriteLine(error);
            //    }).Run();

            //Console.ReadLine();

            //ProcessHandler.Instance.Stop();

            //ProcessHandlerAsync.Instance.RunAsync("accServer.exe", "",
            //    (output) =>
            //    {
            //        Console.WriteLine(output);
            //    },
            //    (error) =>
            //    {
            //        Console.WriteLine(error);
            //    }).GetAwaiter().OnCompleted(() =>
            //    {
            //        Console.WriteLine("Complete");
            //    });

            //Console.ReadLine();
            //var isUse = NetworkHelper.IsTcpPortAvailable(9201);
            //if(isUse)
            //{
            //    Console.WriteLine(isUse);
            //}

            ////NetworkHelper.OpenPort()
            //NetworkHelper.DisableFirewall();

            ACCCServerManagerContainer aCCCServerManagerContainer = new ACCCServerManagerContainer();
            var config = new Shard.Models.ACCCServerConfig()
            {
                Configuration = null,
                Event = null,
                AssistRules = null,
                Settings = new Shard.Models.Settings() { ServerName = "accc_server_kor" }
            };
            var result = aCCCServerManagerContainer.Start(config);
            if(!result.HasError)
            {
                Console.ReadLine();
                var stopResult = aCCCServerManagerContainer.Stop(config.Settings.ServerName);
                if (stopResult.HasError)
                {

                }
            }

            Console.ReadLine();
        }
    }
}
