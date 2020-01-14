using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Web;

namespace Foundation.Lighthouse
{
    public class RecurseItemsProvider : IItemsProvider
    {
        public IEnumerable<Item> GetAllItemsWithPresentationFilteredByTemplate(SiteInfo siteInfo, ID baseTemplateId, string forceDatabase)
        {
            var databaseName = !string.IsNullOrEmpty(forceDatabase) ? forceDatabase : siteInfo.Database;
            var database = Database.GetDatabase(databaseName);
            using (var databaseSwitcher = new DatabaseSwitcher(database))
            {
                var startItem = database.GetItem($"{siteInfo.RootPath}{siteInfo.StartItem}");
                return Recurse(startItem, baseTemplateId);
            }
        }

        private IEnumerable<Item> Recurse(Item item, ID baseTemplateId)
        {
            foreach (Item child in item.Children)
            {
                foreach (var item1 in Recurse(child, baseTemplateId)) yield return item1;
            }

            if (item.Fields[Sitecore.FieldIDs.LayoutField] != null
                && !string.IsNullOrEmpty(item.Fields[Sitecore.FieldIDs.LayoutField].Value)
                && item.Template.BaseTemplates.Select(x=>x.ID == baseTemplateId) != null)
            {
                yield return item;
            }
        }
    }
}