using System;
using System.Web;
using Sitecore.Data.Items;

namespace Foundation.Lighthouse
{
    public class Paths
    {
        public string GetReportsPath(Item item)
        {
            return $"{HttpRuntime.AppDomainAppPath}{Constants.Reports}/{item.Paths.FullPath}".Replace("/", "\\");
        }

        public string GetReportJsonPath(Item item)
        {
            return $"{GetReportsPath(item)}/{GetJsonFileName()}".Replace("/", "\\");
        }

        public string GetReportHtmlPath(Item item)
        {
            return $"{GetReportsPath(item)}/{GetHtmlFileName()}".Replace("/", "\\");
        }

        public void CreateReportDir(Item item)
        {
            System.IO.Directory.CreateDirectory(GetReportsPath(item));
        }

        public string GetLighthouseCmdPath()
        {
            return $"{HttpRuntime.AppDomainAppPath}/{Constants.Tools}/{Constants.LighthouseCmd}";
        }

        private string GetJsonFileName()
        {
            return string.Format(Constants.JsonFileFormat, GetDateTimeStamp());
        }

        private string GetHtmlFileName()
        {
            return string.Format(Constants.HtmlFileFormat, GetDateTimeStamp());
        }

        private string GetDateTimeStamp()
        {
            return DateTime.Now.ToString(Constants.DateTimeFormat);
        }
    }
}