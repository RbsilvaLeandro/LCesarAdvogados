using System.Web.Optimization;

namespace LCesarAdvogados.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/modernizr-2.6.2-respond-1.1.0.min.js",
                      "~/Scripts/jquery.js",
                      "~/Scripts/jquery.easing.1.3.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/jquery.tinycarousel.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme.css",
                      "~/Content/style.css",
                      "~/Content/Carrossel.css"));
        }
    }
}
