﻿using Foundation.Lighthouse.Model.Autogenerated;
using Sitecore.Shell.Framework.Commands;

namespace Foundation.Lighthouse.Commands
{
    public class Run : Base
    {
        private readonly ILighthouseRunner _lighthouseRunner;
        public Run(ILighthouseRunner lighthouseRunner)
        {
            _lighthouseRunner = lighthouseRunner;
        }
        public override void Execute(CommandContext context)
        {
            if (!Verify(context))
            {
                return;
            }

            Sitecore.Diagnostics.Log.Error(context.Items[0].Paths.FullPath, this);
            Sitecore.Diagnostics.Log.Error(context.Items[0].Database.Name, this);
            _lighthouseRunner.Run(context.Items[0], OutputFormat.Html, null, out LighthouseJson null1lighthouseJson);
            _lighthouseRunner.Run(context.Items[0], OutputFormat.Json, null, out LighthouseJson null2lighthouseJson);
        }
    }
}