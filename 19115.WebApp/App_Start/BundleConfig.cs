using System.Web.Optimization;

namespace _19115.WebApp
{
	public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/lib/jquery/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/lib/jquery-validate/jquery.validate.js"));
			
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/lib/modernizr/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/lib/twitter-bootstrap/js/bootstrap.js"));


			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/lib/twitter-bootstrap/css/bootstrap.css",
                      "~/Content/site.css"));
		}
    }
}
