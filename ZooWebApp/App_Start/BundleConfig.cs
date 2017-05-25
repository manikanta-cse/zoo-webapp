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


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/libraries/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                      "~/Scripts/libraries/toastr.js"));

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
