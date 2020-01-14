using Sitecore.Data.Items;
using Sitecore.Web;

namespace Foundation.Lighthouse
{
    public interface IUrls
    {
        string GetItemUrl(Item item, SiteInfo siteInfo);
        SiteInfo GetSite(Item item);
    }
}