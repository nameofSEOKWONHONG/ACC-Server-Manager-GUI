#define __LITE_VERSION__

using ACCCServerApp.Shard.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ACCCServerApp.Shard
{
    public class ACCCServerManagerContainer
    {
        public static readonly Dictionary<string, IACCCServerManager> Containers = new Dictionary<string, IACCCServerManager>();
        public readonly string ServerFilePath = "./server";
        public readonly string ContainerFilePath = "./containers";

        public ACCCServerManagerContainer()
        {

        }

        public ACCCServerResult Start(ACCCServerConfig acServerConfig)
        {
            //CreateContainer(acServerConfig.Settings.ServerName);
            if(Containers.Count > 0)
            {
                return new ACCCServerResult()
                {
                    HasError = true,
                    Message = "No support normal version, plz buy pro version."
                };
            }
            IACCCServerManager serverManager = new ACCCServerManager(acServerConfig);
            Containers.Add(acServerConfig.Settings.ServerName, serverManager);
            return serverManager.Start();
        }

        public ACCCServerResult Stop(string serverName)
        {
            var server = Containers.Where(m => m.Key == serverName).First().Value as IACCCServerManager;
            return server.Stop();
        }

        public void CreateContainer(string serverName)
        {
            DirectoryInfo d1 = new DirectoryInfo(this.ServerFilePath);
            DirectoryInfo d2 = new DirectoryInfo(this.ContainerFilePath + $"/{serverName}");
            CopyAll(d1, d2);
        }

        private void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                //Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}
