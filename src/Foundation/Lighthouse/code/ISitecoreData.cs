﻿using Foundation.Lighthouse.Model;
using Foundation.Lighthouse.Model.Autogenerated;
using Foundation.Lighthouse.Model.Autogenerated.Foundation.Lighthouse.Concrete;
using Sitecore.Data.Items;

namespace Foundation.Lighthouse
{
    public interface ISitecoreData
    {
        bool AddCheckPoint(Item item, LighthouseJson data);
        ILighthouseSiteItem GetOrCreateLighouseSiteItem(string name);
        bool AddCheckPoint(Item item, Checkpoint checkpoint);
    }
}