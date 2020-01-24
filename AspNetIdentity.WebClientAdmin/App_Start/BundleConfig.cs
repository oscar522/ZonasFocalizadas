using System.Web;
using System.Web.Optimization;

namespace AspNetIdentity.WebClientAdmin
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.3.1.min.js",
                        "~/Scripts/popper.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/mdb.min.js",
                        "~/Scripts/addons/datatables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryLogin").Include(
                        "~/Content/login/vendor/jquery/jquery-3.2.1.min.js",
                        "~/Content/login/vendor/animsition/js/animsition.min.js",
                        "~/Content/login/vendor/bootstrap/js/popper.js",
                        "~/Content/login/vendor/bootstrap/js/bootstrap.min.js",
                        "~/Content/login/vendor/select2/select2.min.js",
                        "~/Content/login/vendor/daterangepicker/moment.min.js",
                        "~/Content/login/vendor/daterangepicker/daterangepicker.js",
                        "~/Content/login/vendor/countdowntime/countdowntime.js",
                        "~/Content/login/js/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/mdb.min.css",
                      "~/Content/style.min.css",
                      "~/Content/addons/datatables.min.css"));

            bundles.Add(new StyleBundle("~/Content/cssLogin").Include(
                      "~/Content/login/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/login/fonts/font-awesome-4.7.0/css/font-awesome.min.css",
                      "~/Content/login/fonts/iconic/css/material-design-iconic-font.min.css",
                      "~/Content/login/vendor/animate/animate.css",
                      "~/Content/login/vendor/css-hamburgers/hamburgers.min.css",
                      "~/Content/login/vendor/animsition/css/animsition.min.css",
                      "~/Content/login/vendor/select2/select2.min.css",
                      "~/Content/login/vendor/daterangepicker/daterangepicker.css",
                      "~/Content/login/css/util.css",
                      "~/Content/login/css/main.css"));
        }
    }
}
