using XF.Contatos.App_Code;

namespace XF.Contatos.Droid
{
    public class VersionHelper : IVersionHelper
    {
        public string GetVersionNumber()
        {
            var versionNumber = string.Empty;
            if (MainApplication.CurrentContext != null)
            {
                versionNumber = MainApplication.CurrentContext.PackageManager.GetPackageInfo(MainApplication.CurrentContext.PackageName, 0).VersionName;
            }
            return versionNumber;
        }
    }
}