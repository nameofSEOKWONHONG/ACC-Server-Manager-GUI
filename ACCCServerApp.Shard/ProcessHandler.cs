using JDotnetExtension;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCServerApp.Shard
{
    /// <summary>
    /// process manage for accc server process instance
    /// </summary>
    public class ProcessHandler
    {
        private Process _executor = null;

        public ProcessHandler() { }

        Action<string> _outputReceived;
        Action<string> _errorReceived;

        public ProcessHandler CreateProcess(string fileName, string args, string workingDir, Action<string> outputReceived, Action<string> errorReceived)
        {
            if (_executor != null)
            {
                _executor.Close();
                _executor = null;
            }

            _outputReceived = outputReceived;
            _errorReceived = errorReceived;

            _executor = new Process();
            _executor.StartInfo = new ProcessStartInfo();
            _executor.StartInfo.FileName = fileName;
            _executor.StartInfo.Arguments = args;
            _executor.StartInfo.CreateNoWindow = true;
            _executor.StartInfo.UseShellExecute = false;
            _executor.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            _executor.StartInfo.StandardErrorEncoding = Encoding.UTF8;
            _executor.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            _executor.EnableRaisingEvents = true;

            _executor.StartInfo.RedirectStandardOutput = true;
            _executor.StartInfo.RedirectStandardInput = true;
            _executor.StartInfo.RedirectStandardError = true;
            _executor.StartInfo.WorkingDirectory = workingDir;
            _executor.EnableRaisingEvents = true;

            _executor.OutputDataReceived += (s, e) => _outputReceived(e.Data);
            _executor.ErrorDataReceived += (s, e) => _errorReceived(e.Data);
            
            return this;
        }

        public void Run()
        {
            if (!_executor.Start())
            {
                _executor.BeginOutputReadLine();
                _executor.BeginErrorReadLine();
                _executor.WaitForExit();
                throw new InvalidOperationException("Could not start process");
            }
        }

        public void Stop()
        {
            if (_executor != null)
            {
                _executor.StandardInput.Close();

                _executor.OutputDataReceived -= (s, e) => _outputReceived(e.Data);
                _executor.ErrorDataReceived -= (s, e) => _errorReceived(e.Data);

                _executor.CloseMainWindow();
                _executor.Close();
            }
        }
    }
    public class ProcessHandlerAsync
    {
        public async Task<int> RunAsync(string fileName, string args, Action<string> outputReceived, Action<string> errorReceived)
        {
            using (var process = new Process())
            {
                process.StartInfo = new ProcessStartInfo();
                process.StartInfo.FileName = fileName;
                process.StartInfo.Arguments = args;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                process.StartInfo.StandardErrorEncoding = Encoding.UTF8;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

                process.EnableRaisingEvents = true;

                return await RunAsync(process, outputReceived, errorReceived).ConfigureAwait(false);
            }
        }

        private Task<int> RunAsync(Process process, Action<string> outputReceived, Action<string> errorReceived)
        {
            var tcs = new TaskCompletionSource<int>();

            process.Exited += (s, e) => tcs.SetResult(process.ExitCode);
            process.OutputDataReceived += (s, e) => outputReceived(e.Data);
            process.ErrorDataReceived += (s, e) => errorReceived(e.Data);

            var isStarted = process.Start();
            if (!isStarted)
            {
                throw new InvalidOperationException("Could not start process");
            }

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();

            return tcs.Task;
        }
    }

    public class ProcessSimpleHandler
    {
        readonly string ProcessName = "accServer";
        readonly string ProcessName2 = "accServer.exe";
        readonly string[] CheckProcessNames = new[]
        {
            "accServer", "accServer.exe", "cmd", "cmd.exe"
        };
        public void Run(string fileName, string args, string workingDir)
        {
            var proc = new Process();
            proc.StartInfo = new ProcessStartInfo();
            proc.StartInfo.FileName = "cmd";
            proc.StartInfo.Arguments = string.Format("/{0} {1}", "k", fileName, args);
            //proc.StartInfo.CreateNoWindow = true;
            //proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.WorkingDirectory = workingDir;
            proc.Start();
            //Process.Start("cmd", string.Format("/{0} {1}", "k", fileName, args));
        }

        public void Stop()
        {
            var procs = Process.GetProcesses();
            var exist = procs.Where(p => CheckProcessNames.Where(m => m == p.ProcessName).FirstOrDefault().jIsNotNull()).ToList();
            foreach(var proc in exist)
            {
                proc.CloseMainWindow();
                proc.Close();
            }
        }
    }

    public class ProcessInstance
    {
        public class ProcessHandlerAsync
        {
            private static readonly Lazy<ProcessHandlerAsync> _instance =
                new Lazy<ProcessHandlerAsync>(() => new ProcessHandlerAsync());

            public static ProcessHandlerAsync Instance
            {
                get
                {
                    return _instance.Value;
                }
            }

            public async Task<int> RunAsync(string fileName, string args, Action<string> outputReceived, Action<string> errorReceived)
            {
                using (var process = new Process())
                {
                    process.StartInfo = new ProcessStartInfo();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Arguments = args;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;

                    process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                    process.StartInfo.StandardErrorEncoding = Encoding.UTF8;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

                    process.EnableRaisingEvents = true;

                    return await RunAsync(process, outputReceived, errorReceived).ConfigureAwait(false);
                }
            }

            private Task<int> RunAsync(Process process, Action<string> outputReceived, Action<string> errorReceived)
            {
                var tcs = new TaskCompletionSource<int>();

                process.Exited += (s, e) => tcs.SetResult(process.ExitCode);
                process.OutputDataReceived += (s, e) => outputReceived(e.Data);
                process.ErrorDataReceived += (s, e) => errorReceived(e.Data);

                var isStarted = process.Start();
                if (!isStarted)
                {
                    throw new InvalidOperationException("Could not start process");
                }

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                return tcs.Task;
            }
        }

        public class ProcessHandler
        {
            private static readonly Lazy<ProcessHandler> instance =
                    new Lazy<ProcessHandler>(() => new ProcessHandler());

            public static ProcessHandler Instance
            {
                get
                {
                    return instance.Value;
                }
            }

            private Process _executor = null;

            private ProcessHandler() { }

            public ProcessHandler CreateProcess(string fileName, string args, Action<string> outputReceived, Action<string> errorReceived)
            {
                if (_executor != null)
                {
                    _executor.Close();
                    _executor = null;
                }

                _executor = new Process();
                _executor.StartInfo = new ProcessStartInfo();
                _executor.StartInfo.FileName = fileName;
                _executor.StartInfo.Arguments = args;
                _executor.StartInfo.CreateNoWindow = true;
                _executor.StartInfo.UseShellExecute = false;
                _executor.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                _executor.StartInfo.StandardErrorEncoding = Encoding.UTF8;
                _executor.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

                _executor.StartInfo.RedirectStandardOutput = true;
                _executor.StartInfo.RedirectStandardInput = true;
                _executor.StartInfo.RedirectStandardError = true;
                _executor.EnableRaisingEvents = true;

                _executor.OutputDataReceived += (s, e) => outputReceived(e.Data);
                _executor.ErrorDataReceived += (s, e) => errorReceived(e.Data);

                return this;
            }

            public void Run()
            {
                if (!_executor.Start())
                {
                    throw new InvalidOperationException("Could not start process");
                }
                _executor.BeginOutputReadLine();
                _executor.BeginErrorReadLine();
            }

            public void Stop()
            {
                if (_executor != null)
                {
                    _executor.StandardInput.Close();
                    _executor.Close();
                }

                try
                {
                    if (!_executor.HasExited)
                    {
                        _executor.StandardInput.Close();
                        _executor.Kill();
                    }
                }
                finally
                {
                    _executor = null;
                }
            }
        }
    }
}
