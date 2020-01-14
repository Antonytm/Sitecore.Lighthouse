using Sitecore.Data.Items;
using Sitecore.Web;

namespace Foundation.Lighthouse
{
    public interface ILighthouseRunner
    {
        bool Run(Item item, OutputFormat format, SiteInfo siteInfo);
        void RunAll();
    }
}