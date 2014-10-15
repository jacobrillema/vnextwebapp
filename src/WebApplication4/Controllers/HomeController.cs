using System.Reflection;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Runtime;

namespace WebApplication4.Controllers
{
	public class HomeController : Controller
    {
		IApplicationEnvironment AppEnv { get; set; }

		public HomeController(IApplicationEnvironment env)
		{
			AppEnv = env;
		}

		public IActionResult Index()
        {
			var assembly = typeof(HomeController).GetTypeInfo().Assembly;
			var attr = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
			ViewBag.ApplicationVersion = attr.InformationalVersion;

			var klr = Assembly.Load(new AssemblyName("klr.host"));
			var version = klr.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
			ViewBag.ApplicationVersion = AppEnv.Version;
			ViewBag.ApplicationName = AppEnv.ApplicationName;
			ViewBag.KREVersion = version.InformationalVersion;
			ViewBag.KREFrameworkName = AppEnv.RuntimeFramework.FullName;
			ViewBag.KREAppBase = AppEnv.ApplicationBasePath;
			ViewBag.Configuration = AppEnv.Configuration;
			return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}