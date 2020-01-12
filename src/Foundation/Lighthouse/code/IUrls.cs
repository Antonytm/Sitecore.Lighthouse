using Sitecore.Data.Items;
using Sitecore.Web;

namespace Foundation.Lighthouse
{
    public interface IUrls
    {
        string GetItemUrl(Item item);
        SiteInfo GetSite(Item item);
    }
}