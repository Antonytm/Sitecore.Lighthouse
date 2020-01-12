using Sitecore.Data.Items;

namespace Foundation.Lighthouse
{
    public interface ILighthouseRunner
    {
        bool Run(Item item, OutputFormat format);
    }
}