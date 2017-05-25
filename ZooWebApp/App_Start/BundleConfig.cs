using System.Web;
using System.Web.Optimization;

namespace ZooWebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/libraries/jquery-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/unobstrusive").Include(
                      "~/Scripts/libraries/jquery.validate.js",
                      "~/Scripts/libraries/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/libraries/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/libraries/bootstrap.js",
                      "~/Scripts/libraries/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                      "~/Scripts/libraries/toastr.js",
                      "~/Scripts/libraries/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                     "~/Scripts/libraries/angular.min.js",
                     "~/Scripts/libraries/angular-route.min.js"));

                

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css"));
            

            bundles.Add(new ScriptBundle("~/bundles/app").
            Include("~/Scripts/app/app.js")     
            .IncludeDirectory("~/Scripts/app/services", "*.js")
             .IncludeDirectory("~/Scripts/app/controllers", "*.js"));
            
        }
    }
}
