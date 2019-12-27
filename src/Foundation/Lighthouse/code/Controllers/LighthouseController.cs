using System;
using System.Web.Mvc;

namespace Foundation.Lighthouse.Controllers
{
    public class LighthouseController : Controller
    {
        private readonly Paths _paths;
        public LighthouseController()
        {
            _paths = new Paths();
        }
        public ActionResult ShowFileContent(string filename, string itemId, string database)
        {
            try
            {
                var item = Sitecore.Data.Database.GetDatabase(database).GetItem(itemId);
                var filepath = $"{_paths.GetReportsPath(item)}\\{filename}";
                return new ContentResult() {Content = System.IO.File.ReadAllText(filepath)};
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error($"Lighthouse: was not able find file:'{filename}', itemId:{itemId}, database:{database}",ex, this);
                return new ContentResult(){Content = "Sorry, exception happened. Please check Sitecore logs."};
            }
        }
    }
}