using System.Collections.Generic;
using Sitecore.Data;

namespace Foundation.Lighthouse
{
    public static class Constants
    {
        public const string Root = "App_data/Lighthouse";
        public const string Reports = Root + "/Reports";
        public const string Tools = Root + "/Tools";
        public const string LighthouseCmd = "lighthouse.cmd";
        public const string DateTimeFormat = "yyyyMMddhhmmss";
        public const string JsonFileFormat = "{0}.json";
        public const string HtmlFileFormat = "{0}.html";

        public static readonly List<string> ServiceSites = new List<string>()
        {
            "shell", "login", "admin", "service", "modules_shell", "modules_website", "scheduler", "publisher", "exm", "unicorn"
        };

        public static readonly ID LighthouseTemplate = new ID("{BB102C6B-C167-4453-9A76-BC44F8889424}");
    }
}