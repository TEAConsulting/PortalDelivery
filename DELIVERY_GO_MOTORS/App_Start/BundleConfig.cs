using System.Web;
using System.Web.Optimization;

namespace ZPIDI_PORTAL
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //---------------------------PUBLIC PAGE----------------------------------
            bundles.Add(new StyleBundle("~/PublicBundles/CSS").Include(
                "~/Content/PublicTemplate/lib/owlcarousel/assets/owl.carousel.min.css",
                "~/Content/PublicTemplate/lib/tempusdominus/css/tempusdominus-bootstrap-4.min.css",
                "~/Content/PublicTemplate/lib/lightbox/css/lightbox.min.css",
                "~/Content/PublicTemplate/css/bootstrap.min.css",
                "~/Content/css/bootstrap-multiselect.css",
                "~/Content/PublicTemplate/css/style.css"
                ));

            bundles.Add(new ScriptBundle("~/PublicBundles/JS").Include(
                "~/Content/PublicTemplate/lib/easing/easing.min.js",
                "~/Content/PublicTemplate/lib/waypoints/waypoints.min.js",
                "~/Content/PublicTemplate/lib/owlcarousel/owl.carousel.min.js",
                "~/Content/PublicTemplate/lib/tempusdominus/js/moment.min.js",
                "~/Content/PublicTemplate/lib/tempusdominus/js/moment-timezone.min.js",
                "~/Content/PublicTemplate/lib/tempusdominus/js/tempusdominus-bootstrap-4.min.js",
                "~/Content/PublicTemplate/lib/isotope/isotope.pkgd.min.js",
                "~/Content/PublicTemplate/lib/lightbox/js/lightbox.min.js",
                "~/Content/PublicTemplate/js/main.js"
               ));


            //-------------------------------ADMIN PAGE-------------------------------
            bundles.Add(new StyleBundle("~/AdminBundles/CSS").Include(
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/style.css",
                "~/Content/css/responsive.css",
                "~/Content/css/color_2.css",
                "~/Content/css/bootstrap-select.css",
                "~/Content/css/perfect-scrollbar.css",
                "~/Content/css/custom.css",
                "~/Content/css/font-awesome.min.css",
                "~/Content/css/custom.css",
                "~/Content/css/semantic.min.css",
                "~/Content/css/select/select2.min.css",
                "~/Content/css/bootstrap-multiselect.css",
                "~/Content/css/animate.css"
                ));
            
            bundles.Add(new ScriptBundle("~/AdminBundles/JS").Include(
            "~/Content/js/jquery-3.3.1.min.js",
            "~/Content/js/popper.min.js",
            "~/Content/js/bootstrap.min.js",
            "~/Content/js/bootstrap-select.js",
             "~/Content/js/select/select2.full.js",
            "~/Content/js/animate.js",
            "~/Content/js/owl.carousel.js",
            "~/Content/js/Chart.min.js",
            "~/Content/js/Chart.bundle.min.js",
            "~/Content/js/utils.js",
            "~/Content/js/analyser.js",
            "~/Content/js/custom.js",
            "~/Content/js/perfect-scrollbar.min.js"
            ));

            bundles.Add(new ScriptBundle("~/AdminBundles_multiselect/JS").Include(
                "~/Content/js/bootstrap-multiselect.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));


            bundles.Add(new ScriptBundle("~/bundles/Perfect-Scroll").Include(
                        "~/Content/js/perfect-scrollbar.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/Chart-Custom").Include(
                       "~/Content/js/chart_custom_style1.js"));

            //Librerias
            bundles.Add(new ScriptBundle("~/bundles/DataTable").Include(
                "~/Content/js/DataTable/jquery.dataTables.min.js",

                "~/Content/js/DataTable/dataTables.bootstrap.js",
                "~/Content/js/DataTable/dataTables.buttons.min.js",
                "~/Content/js/DataTable/buttons.bootstrap.min.js",
                "~/Content/js/DataTable/buttons.html5.min.js",
                "~/Content/js/DataTable/buttons.print.min.js",
                "~/Content/js/DataTable/dataTables.keyTable.min.js",
                "~/Content/js/DataTable/dataTables.responsive.min.js",
                "~/Content/js/DataTable/responsive.bootstrap.min.js",

                //"~/Content/js/datatables/dataTables.bootstrap.js",
                // "~/Content/js/datatables/dataTables.buttons.min.js",
                // "~/Content/js/datatables/buttons.bootstrap.min.js",
                "~/Content/js/datatables/jszip.min.js",
                "~/Content/js/datatables/pdfmake.min.js",
                "~/Content/js/datatables/vfs_fonts.js",
                //"~/Content/js/datatables/buttons.html5.min.js",
                //"~/Content/js/datatables/buttons.print.min.js",
                "~/Content/js/datatables/dataTables.fixedHeader.min.js",
                //"~/Content/js/datatables/dataTables.keyTable.min.js",
                //"~/Content/js/datatables/dataTables.responsive.min.js",
                //"~/Content/js/datatables/responsive.bootstrap.min.js",
                "~/Content/js/datatables/dataTables.scroller.min.js"
                ));


            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

        }


    }
}
