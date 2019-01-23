using System.Web.Optimization;

namespace Store.LegacyWeb
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bootstrap/js").Include("~/js/bootstrap.js", "~/js/site.js"));
            bundles.Add(new StyleBundle("~/bootstrap/css").Include("~/css/bootstrap.css", "~/css/site.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}