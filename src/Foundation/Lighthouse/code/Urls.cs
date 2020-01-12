using System;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Sites;
using Sitecore.Web;

namespace Foundation.Lighthouse
{
    public class Urls : IUrls
    {
        public string GetItemUrl(Item item)
        {
            var options = new UrlOptions()
            {
                AlwaysIncludeServerUrl = true,
            };

            var site = GetSite(item);
            using (new SiteContextSwitcher(new SiteContext(site)))
            {
                return LinkManager.GetItemUrl(item, options);
            }
        }

        public SiteInfo GetSite(Item item)
        {
            var siteInfoList = Sitecore.Configuration.Factory.GetSiteInfoList();

            SiteInfo currentSiteinfo = null;
            var matchLength = 0;
            foreach (var siteInfo in siteInfoList.Where(x => !Constants.ServiceSites.Contains(x.Name)))
            {
                if (item.Paths.FullPath.StartsWith(siteInfo.RootPath, StringComparison.OrdinalIgnoreCase) && siteInfo.RootPath.Length > matchLength)
                {
                    matchLength = siteInfo.RootPath.Length;
                    currentSiteinfo = siteInfo;
                }
            }

            return currentSiteinfo;
        }
    }
}