#define __LITE_VERSION__

using ACCServerApp.Shard.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ACCServerApp.Shard
{
    /// <summary>
    /// ACCC Server Container (for create multiple server session)
    /// </summary>
    public class ACCServerManagerContainer
    {
        public static readonly Dictionary<string, IACCServerManager> Containers = new Dictionary<string, IACCServerManager>();
        public readonly string ServerFilePath = "./server";
        public readonly string ContainerFilePath = "./containers";

        public ACCServerManagerContainer()
        {

        }

        public ACCCServerResult Start(ACCServerConfig acServerConfig)
        {
            CreateContainer(acServerConfig.Settings.ServerName);
            if(Containers.Count > 0)
            {
                return new ACCCServerResult()
                {
                    HasError = true,
                    Message = "No support normal version, plz buy pro version."
                };
            }
            IACCServerManager serverManager = new ACCServerManager(acServerConfig);
            Containers.Add(acServerConfig.Settings.ServerName, serverManager);

            DirectoryInfo driInfo = new DirectoryInfo(this.ContainerFilePath + $"/{acServerConfig.Settings.ServerName}");

            ACCServerFileManager accFileManager = new ACCServerFileManager(acServerConfig);
            accFileManager.ConfigSave(driInfo);

            if(serverManager.Start().HasError)
            {
                Containers.Remove(acServerConfig.Settings.ServerName);
            }
            return serverManager.Start();
        }

        public ACCCServerResult Stop(string serverName)
        {
            var server = Containers.Where(m => m.Key == serverName).First().Value as IACCServerManager;
            var result = server.Stop();
            if(!result.HasError)
            {
                Containers.Remove(serverName);
            }
            return result;
        }

        public void CreateContainer(string serverName)
        {
            DirectoryInfo d1 = new DirectoryInfo(this.ServerFilePath);
            DirectoryInfo d2 = new DirectoryInfo(this.ContainerFilePath + $"/{serverName}");
            CopyAll(d1, d2);
        }

        private void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            if (!Directory.Exists(target.FullName))
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
}
