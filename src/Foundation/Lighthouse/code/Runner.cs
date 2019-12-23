using System;
using System.Collections.Concurrent;
using Sitecore.Data.Items;

namespace Foundation.Lighthouse
{
    public class LighthouseRunner
    {
        private Paths _paths;
        private Urls _urls;
        public LighthouseRunner()
        {
            _paths = new Paths();
            _urls = new Urls();
        }
        public bool Run(Item item, OutputFormat format)
        {
            var processOutput = new ConcurrentBag<string>();
            _paths.CreateReportDir(item);

            var process = new System.Diagnostics.Process();
            var startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = _paths.GetLighthouseCmdPath();
            //startInfo.Arguments = $"/c \"";
            startInfo.Arguments += $"{_urls.GetItemUrl(item)}";
            switch (format)
            {
                case OutputFormat.Html:
                    startInfo.Arguments += GetOutputPath(_paths.GetReportHtmlPath(item));
                    break;
                case OutputFormat.Json:
                    startInfo.Arguments += GetOutputPath(_paths.GetReportJsonPath(item));
                    startInfo.Arguments += GetOutputFormat(format);
                    break;
            }

            //startInfo.Arguments += "\"";
            //startInfo.UseShellExecute = false;
            //startInfo.RedirectStandardOutput = true;
            //startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            process.StartInfo = startInfo;
            process.OutputDataReceived += (sender, eventArgs) => processOutput.Add(eventArgs.Data);
            process.ErrorDataReceived += (sender, eventArgs) => processOutput.Add(eventArgs.Data);

            Sitecore.Diagnostics.Log.Error(startInfo.FileName, this);
            Sitecore.Diagnostics.Log.Error(startInfo.Arguments, this);
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit(20000);
            return process.ExitCode == 0;
        }

        private string GetOutputPath(string path)
        {
            return $" --output-path {path}";
        }

        private string GetOutputFormat(OutputFormat format)
        {
            return $" --output {Enum.GetName(typeof(OutputFormat), format)?.ToLower()}";
        }
    }
}