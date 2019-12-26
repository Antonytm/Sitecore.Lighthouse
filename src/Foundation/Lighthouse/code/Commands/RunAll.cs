using System;
using Sitecore.Shell.Framework.Commands;

namespace Foundation.Lighthouse.Commands
{
    public class RunAll : Command
    {
        private readonly LighthouseRunner _lighthouseRunner;
        public RunAll()
        {
            _lighthouseRunner = new LighthouseRunner();
        }
        public override void Execute(CommandContext context)
        {
            throw new NotImplementedException();
        }
    }
}