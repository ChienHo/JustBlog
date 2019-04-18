using System.Web.Optimization;

namespace FA.JustBlog.Presentation
{
    public class BundleConfig
    {
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
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //// Use for my theme
            bundles.Add(new StyleBundle("~/bundles/Mytheme/css").Include(
                "~/Content/Theme/css/bootstrap.css",
                "~/Content/Theme/vendors/linericon/style.css",
                "~/Content/Theme/css/font-awesome.min.css",
                "~/Content/Theme/vendors/owl-carousel/owl.carousel.min.css",
                "~/Content/Theme/vendors/lightbox/simpleLightbox.css",
                "~/Content/Theme/vendors/nice-select/css/nice-select.css",
                "~/Content/Theme/vendors/animate-css/animate.css",
                "~/Content/Theme/vendors/jquery-ui/jquery-ui.css",
                "~/Content/Theme/css/style.css",
                "~/Content/Theme/css/css/responsive.css"));

            bundles.Add(new ScriptBundle("~/bundles/Mytheme/js").Include(
                "~/Content/Theme/js/jquery-3.2.1.min.js",
                "~/Content/Theme/js/popper.js",
                "~/Content/Theme/js/bootstrap.min.js",
                "~/Content/Theme/js/stellar.js",
                "~/Content/Theme/vendors/lightbox/simpleLightbox.min.js",
                "~/Content/Theme/vendors/nice-select/js/jquery.nice-select.min.js",
                "~/Content/Theme/vendors/isotope/imagesloaded.pkgd.min.js",
                "~/Content/Theme/vendors/isotope/isotope-min.js",
                "~/Content/Theme/vendors/owl-carousel/owl.carousel.min.js",
                "~/Content/Theme/vendors/jquery-ui/jquery-ui.js",
                "~/Content/Theme/js/mail-script.js",
                "~/Content/Theme/js/theme.js"));

            bundles.Add(new StyleBundle("~/bundles/Admin/css").Include(
                "~/Content/Theme/css/bootstrap.css",
                "~/Areas/Content/css/sb-admin-2.min.css",
                "~/Areas/Content/vendor/fontawesome-free/css/all.min.css",
                "~/Areas/Content/css/bootstrap-tagsinput.css"));

            bundles.Add(new ScriptBundle("~/bundles/Admin/bootstrap").Include(
                "~/Areas/Content/vendor/jquery/jquery.min.js",
                "~/Areas/Content/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Areas/Content/vendor/jquery-easing/jquery.easing.min.js"));
        }
    }
}
