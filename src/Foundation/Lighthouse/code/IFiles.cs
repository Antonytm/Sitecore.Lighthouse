using System.IO;
using Sitecore.Data.Items;

namespace Foundation.Lighthouse
{
    public interface IFiles
    {
        FileInfo GetLatestHtmlReportFile(Item item);
    }
}