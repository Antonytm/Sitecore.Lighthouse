using System.IO;
using System.Linq;
using Sitecore.Data.Items;

namespace Foundation.Lighthouse
{
    public class Files
    {
        private readonly Paths _paths;

        public Files()
        {
            _paths = new Paths();
        }
        public FileInfo GetLatestHtmlReportFile(Item item)
        {
            var directory = new DirectoryInfo(_paths.GetReportsPath(item));
            var latestFile = directory.GetFiles("*.html")
                .OrderByDescending(f => f.LastWriteTime)
                .FirstOrDefault();
            return latestFile;
        }
    }
}