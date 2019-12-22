using System;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Sites;
using Sitecore.Web;

namespace Foundation.Lighthouse
{
    public class Urls
    {
        public string GetItemUrl(Item item)
        {
            var options = new UrlOptions()
            {
                AlwaysIncludeServerUrl = true,
            };

            var site = GetSite(item);
            using (new SiteContextSwitcher(SiteContext.GetSite("website")))
            {
                return LinkManager.GetItemUrl(item, options);
            }
        }

        public SiteInfo GetSite(Item item)
        {
            var siteInfoList = Sitecore.Configuration.Factory.GetSiteInfoList();

            SiteInfo currentSiteinfo = null;
            var matchLength = 0;
            foreach (var siteInfo in siteInfoList)
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