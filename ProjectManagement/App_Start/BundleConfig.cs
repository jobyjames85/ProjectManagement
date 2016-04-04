using System.Web;
using System.Web.Optimization;

namespace ProjectManagement
{
    public class BundleConfig
    {
        #region Public Methods

        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/metisMenu.js",
                      "~/Scripts/raphael.js",
                      "~/Scripts/morris.js",
                      "~/Scripts/TableHeaderScript.js",
                      "~/Scripts/sb-admin-2.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/metisMenu.css",
                      "~/Content/timeline.css",
                      "~/Content/sb-admin-2.css",
                      "~/Content/morris.css",
                      "~/Content/font-awesome.css",
                      "~/Content/build.css"));

            bundles.Add(new ScriptBundle("~/validations").Include(
                 "~/Scripts/jquery.validate.js",
                 "~/Scripts/jquery.validate.unobtrusive.js"
                ));
        }

        #endregion Public Methods
    }
}