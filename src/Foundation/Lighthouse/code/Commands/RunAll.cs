using System;
using System.Threading.Tasks;
using Sitecore.Shell.Framework.Commands;

namespace Foundation.Lighthouse.Commands
{
    public class RunAll : Command
    {
        private readonly ILighthouseRunner _lighthouseRunner;
        public RunAll(ILighthouseRunner lighthouseRunner)
        {
            _lighthouseRunner = lighthouseRunner;
        }
        public override void Execute(CommandContext context)
        {
            Task.Run((Action)_lighthouseRunner.RunAll);
        }
    }
}