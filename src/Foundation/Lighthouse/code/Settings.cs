namespace Foundation.Lighthouse
{
    public static class Settings
    {
        public static int ProcessTimeout
        {
            get
            {
                var value = Sitecore.Configuration.Settings.GetSetting("Lighthouse.Process.Timeout");
                if (!string.IsNullOrEmpty(value))
                {
                    return int.Parse(value);
                }
                return 30000;
            }
        }

        public static string ItemsSitesPath
        {
            get
            {
                var value = Sitecore.Configuration.Settings.GetSetting("Lighthouse.Items.Sites.Path");
                return value ?? "/sitecore/system/Modules/Lighthouse";
            }
        }
    }
}