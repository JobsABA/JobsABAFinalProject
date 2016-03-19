using System.Web;
using System.Web.Optimization;

namespace JobsInABA.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bootstrap").Include(
                     "~/Assets/Bootstrap/js/bootstrap.js"));

            //Moved bootstrap css to own style tag in the _layout page.  This is to remove it from the optimizations which was breaking the fonts and icons.
            bundles.Add(new StyleBundle("~/styles").IncludeDirectory("~/Assets", "*.css", true));


            bundles.Add(new ScriptBundle("~/angular").Include(
                        "~/Scripts/angular.min.js",
                        "~/Scripts/angular-route.min.js"));

            bundles.Add(new ScriptBundle("~/jquery").Include(
                        "~/Scripts/jquery-2.2.0.min.js"));

            //bundles.Add(new ScriptBundle("~/misc").IncludeDirectory("~/Assets/misc", "*.js", true));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
