using Sitecore.Data.Items;

namespace Foundation.Lighthouse
{
    public interface IPaths
    {
        string GetReportsPath(Item item);
        string GetReportJsonPath(Item item);
        string GetReportHtmlPath(Item item);
        void CreateReportDir(Item item);
        string GetLighthouseCmdPath();
    }
}