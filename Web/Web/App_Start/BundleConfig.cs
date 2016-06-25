// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the BundleConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Erzasoft.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/content/css").Include(
                "~/css/colorbox.css",
                "~/css/LightBox/lightbox.css",
                 "~/css/site.css"
            ));


            bundles.Add(new StyleBundle("~/content/admincss").Include(
                "~/css/admin.css"));

            bundles.Add(new StyleBundle("~/content/kendocss").Include(
                "~/css/colorbox.css",
                "~/css/kendo/kendo.common.css",
                "~/css/kendo/kendo.common-material.css",
                "~/css/kendo/kendo.material.css"));

            bundles.Add(
                new ScriptBundle("~/bundles/jquery").Include(
                "~/scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                //"~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.validate.additional-methods.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr.custom.69142.js",
                "~/Scripts/jquery.hoverfold.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/frontscripts").Include(
                //"~/Scripts/jquery.nivo.slider.js",
                //"~/Scripts/jquery.colorbox.js",
                //"~/Scripts/jquery.ezmark.js",
                "~/Scripts/MessageLocalization/messages_cs.js",
                //"~/Scripts/eshop.login.js",
                //"~/Scripts/eshop.js",
                //"~/Scripts/eshop.slider.js",
                //"~/Scripts/eshop.cart.js",
                //"~/Scripts/eshop.account.js",
                //"~/Scripts/eshop.product.js",
                //"~/Scripts/eshop.shippingPayment.js",
                //"~/Scripts/eshop.searchmenu.js",
                "~/Scripts/lightbox-{version}.js",
                "~/Scripts/json2.js",
                "~/Scripts/jquery.form.js",
                "~/Scripts/prettyCheckable/prettyCheckable.min.js",
                "~/Scripts/placeholder.js",
                "~/Scripts/maskedit.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

            // The Kendo JavaScript bundle
            bundles.Add(new ScriptBundle("~/bundles/kendofront").Include(
                    "~/Scripts/Kendo/kendo.web.js", // or kendo.all.* if you want to use Kendo UI Web and Kendo UI DataViz
                    "~/Scripts/Kendo/kendo.aspnetmvc.js",
                    "~/Scripts/Kendo/kendo.validator.js",
                    "~/Scripts/Kendo/cultures/kendo.culture.cs-CZ.js",
                    "~/Scripts/kendoEditorCleaner.js",
                    "~/Scripts/kendo.GridHelper.js",
                    "~/Scripts/erzasoft/editajaxwindow.js",
                    "~/Scripts/MessageLocalization/messages_cs.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminkendoscripts").Include(
                    "~/Scripts/Kendo/kendo.web.js", // or kendo.all.* if you want to use Kendo UI Web and Kendo UI DataViz
                    "~/Scripts/Kendo/kendo.aspnetmvc.js",
                    "~/Scripts/Kendo/kendo.validator.js",
                    "~/Scripts/Kendo/cultures/kendo.culture.cs-CZ.js",
                    "~/Scripts/kendoEditorCleaner.js",
                    "~/Scripts/kendo.GridHelper.js"));

            // Javascripty pro administrátora
            bundles.Add(new ScriptBundle("~/bundles/adminscripts").Include(
                "~/Scripts/erzasoft/editajaxwindow.js",
                "~/Scripts/MessageLocalization/messages_cs.js",
                "~/Scripts/jquery.form.js"));

            // Javascripty pro administrátora
            bundles.Add(new ScriptBundle("~/bundles/cmsscripts").Include(
                  "~/Scripts/Kendo/kendo.web.js",
                "~/Scripts/Kendo/kendo.aspnetmvc.js",
                "~/Scripts/Kendo/cultures/kendo.culture.cs-CZ.js",
                "~/Scripts/erzasoft.cms.js"));

            bundles.IgnoreList.Clear();
        }
    }
}
