using Sitecore.Shell.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foundation.Lighthouse.Commands
{
    public class Run : Command
    {
        public override void Execute(CommandContext context)
        {
            Sitecore.Context.ClientPage.ClientResponse.Alert("Testing my button");
        }
    }
}