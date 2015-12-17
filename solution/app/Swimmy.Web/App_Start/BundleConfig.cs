using System.Web;
using System.Web.Optimization;

namespace Swimmy.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
			.Include("~/Scripts/Vendors/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendors")
			.Include("~/Scripts/Vendors/jquery.js",
                     "~/Scripts/Vendors/bootstrap.js", 
                     "~/Scripts/Vendors/toastr.js",
                     "~/Scripts/Vendors/jquery.raty.js",
                     "~/Scripts/Vendors/respond.src.js",                     
                     "~/Scripts/Vendors/angular.js",
                     "~/Scripts/Vendors/angular-route.js",
                     "~/Scripts/Vendors/angular-cookies.js",
                     "~/Scripts/Vendors/angular-validator.js",
                     "~/Scripts/Vendors/angular-base64.js",
                     "~/Scripts/Vendors/angular-file-upload.js",
                     "~/Scripts/Vendors/angucomplete-alt.min.js",
                     "~/Scripts/Vendors/ui-bootstrap-tpls.js",
                     "~/Scripts/Vendors/underscore.js",
                     "~/Scripts/Vendors/raphael.js",
                     "~/Scripts/Vendors/morris.js",
                     "~/Scripts/Vendors/jquery.fancybox.js",
                     "~/Scripts/Vendors/jquery.fancybox-pack.js",
                     "~/Scripts/Vendors/loading-bar.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/spa")
            .Include("~/Scripts/spa/modules/common.core.js",
                     "~/Scripts/spa/modules/common.ui.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css")
            .Include("~/Content/bootstrap.css",
                     "~/Content/bootstrap-theme.css",
                          "~/Content/site.css",
                          "~/Content/font-awesome.css",
                          "~/Content/morris.css",
                      "~/Content/toastr.css"
                      ));

            BundleTable.EnableOptimizations = false;
        }
    }
}
