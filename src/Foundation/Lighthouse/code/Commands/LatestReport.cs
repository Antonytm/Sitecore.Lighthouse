using System;
using Sitecore.Shell.Framework.Commands;

namespace Foundation.Lighthouse.Commands
{
    public class LatestReport : Command
    {
        private readonly LighthouseRunner _lighthouseRunner;
        public LatestReport()
        {
            _lighthouseRunner = new LighthouseRunner();
        }
        public override void Execute(CommandContext context)
        {
            throw new NotImplementedException();
        }
    }
}