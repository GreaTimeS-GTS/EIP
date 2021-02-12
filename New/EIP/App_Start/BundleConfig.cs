using System.Web;
using System.Web.Optimization;

namespace EIP
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js", "~/assets/plugins/jquery-1.10.2.js", "~/assets/plugins/bootstrap/bootstrap.min.js", "~/assets/plugins/metisMenu/jquery.metisMenu.js", "~/assets/plugins/pace/pace.js", "~/assets/scripts/siminta.js", "~/assets/plugins/morris/raphael-2.1.0.min.js", "~/assets/plugins/morris/morris.js", "~/assets/scripts/dashboard-demo.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css", "~/assets/plugins/bootstrap/bootstrap.css", "~/assets/font-awesome/css/font-awesome.css", "~/assets/plugins/pace/pace-theme-big-counter.css", "~/assets/css/style.css", "~/assets/css/main-style.css", "~/assets/plugins/morris/morris-0.4.3.min.css"));
          
        }
    }
}
