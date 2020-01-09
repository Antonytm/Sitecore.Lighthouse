using System.IO;
using System.Linq;
using System.Web;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;

namespace Foundation.Lighthouse.Commands
{
    public class LatestReport : Command
    {
        private readonly Paths _paths;
        public LatestReport()
        {
            _paths = new Paths();
        }
        public override void Execute(CommandContext context)
        {
            var item = context.Items[0];
            var directory = new DirectoryInfo(_paths.GetReportsPath(item));
            var latestFile = directory.GetFiles("*.html")
                .OrderByDescending(f => f.LastWriteTime)
                .FirstOrDefault();
            if (latestFile != null)
            {
                //Do not disclose internal server configuration to user
                var url = $"{HttpContext.Current.Request.Url.Scheme}://{HttpContext.Current.Request.Url.Host}/api/sitecore/lighthouse/ShowFileContent?filename={latestFile.Name}&database={item.Database}&itemId={item.ID}";
                SheerResponse.ShowModalDialog(new ModalDialogOptions(url) { Response = false, Width = "1000", Height = "700"});
            }
            else
            {
                SheerResponse.ShowError("Latest Lighthouse report was not found.",
                    "Please, try to run report creation before trying to open it.");
            }
        }
    }
}