using Sitecore.Shell.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foundation.Lighthouse.Commands
{
    public class Run : Command
    {
        private LighthouseRunner _lighthouseRunner;
        public Run()
        {
            _lighthouseRunner = new LighthouseRunner();
        }
        public override void Execute(CommandContext context)
        {
            Sitecore.Diagnostics.Log.Error(context.Items[0].Paths.FullPath, this);
            Sitecore.Diagnostics.Log.Error(context.Items[0].Database.Name, this);
            _lighthouseRunner.Run(context.Items[0], OutputFormat.Html);
            _lighthouseRunner.Run(context.Items[0], OutputFormat.Json);
        }
    }
}