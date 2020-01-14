using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Web;

namespace Foundation.Lighthouse
{
    public interface IItemsProvider
    {
        IEnumerable<Item> GetAllItemsWithPresentationFilteredByTemplate(SiteInfo siteInfo, ID baseTemplateId, string forceDatabase);
    }
}