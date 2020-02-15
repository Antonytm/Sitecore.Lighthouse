using System.Collections.Generic;
using System.Linq;
namespace Foundation.Lighthouse
{
    public static class Settings
    {
        public static int ProcessTimeout
        {
            get
            {
                var value = Sitecore.Configuration.Settings.GetSetting("Lighthouse.Process.Timeout");
                if (!string.IsNullOrEmpty(value))
                {
                    return int.Parse(value);
                }
                return 30000;
            }
        }

        public static string ItemsSitesPath
        {
            get
            {
                var value = Sitecore.Configuration.Settings.GetSetting("Lighthouse.Items.Sites.Path");
                return value ?? "/sitecore/system/Modules/Lighthouse";
            }
        }
        
        /// <summary>
        /// List of websites that should be ignored during running Google Lighthouse for all pages(items)
        /// </summary>
        public static IEnumerable<string> WebsitesToIgnore
        {
            get
            {
                var value = Sitecore.Configuration.Settings.GetSetting("Lighthouse.Websites.To.Ignore");
                return !string.IsNullOrEmpty(value) 
                    ? value.Split(',').Select(x => x.Trim()) 
                    : new List<string>();
            }
        }
    }
}