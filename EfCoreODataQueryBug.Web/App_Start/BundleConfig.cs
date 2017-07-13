using System.Web;
using System.Web.Optimization;

namespace EfCoreODataQueryBug.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/tools").Include(
            "~/Scripts/jquery-{version}.js",
            "~/Scripts/knockout-{version}.js",
            "~/Scripts/cldr.js",
            "~/Scripts/cldr/event.js",
            "~/Scripts/cldr/supplemental.js",
            "~/Scripts/globalize.js",
            "~/Scripts/globalize/message.js",
            "~/Scripts/globalize/number.js",
            "~/Scripts/globalize/currency.js",
            "~/Scripts/globalize/date.js",
            "~/Scripts/cldr-data/likelySubtags.js",
            "~/Scripts/cldr-data/numbers.js",
            "~/Scripts/cldr-data/currencies.js",
            "~/Scripts/cldr-data/ca-gregorian.js",
            "~/Scripts/cldr-data/nb/numbers.js",
            "~/Scripts/cldr-data/nb/currencies.js",
            "~/Scripts/cldr-data/nb/ca-gregorian.js",
            "~/Scripts/dx.viz-web.js",
            "~/Scripts/devextreme-localization/dx.messages.en.js",
            "~/Scripts/devextreme-localization/dx.messages.nb.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/home-index").Include(
            "~/AppScripts/home-index.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/appscripts").Include(
            "~/AppScripts/HomeViewModel.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/bundles/dxcss").Include(
                      "~/Content/dx.common.css",
                      "~/Content/dx.light.css",
                      "~/Content/bootstrap.css"));
        }
    }
}
