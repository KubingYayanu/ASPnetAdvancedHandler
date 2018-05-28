using System.Web.Optimization;

namespace ModelBinder.Web.App_Start
{
    public class BundleConfig
    {
        // 如需「搭配」的詳細資訊，請瀏覽 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/jquery-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));

        }
    }
}