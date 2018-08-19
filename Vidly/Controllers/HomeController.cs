using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.ViewModels;
using Vidly.Models;

namespace Vidly.Controllers
{
   

    public static class JavaScriptConvert
    {
        public static IHtmlString SerializeObject(object value)
        {
            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var serializer = new JsonSerializer
                {
                    // Let's use camelCasing as is common practice in JavaScript
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                // We don't want quotes around object names
                jsonWriter.QuoteName = false;
                serializer.Serialize(jsonWriter, value);

                return new HtmlString(stringWriter.ToString());
            }
        }
    }


    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var allChartData = new List<ChartData> { };

            var c1 = new ChartData
            {
                name = "Asia",
                data = new List<int>{ 502, 635, 809, 947, 1402, 3634, 5268 }
            };
            
            allChartData.Add(c1);
            allChartData.Add(new ChartData
            {
                name = "Africa",
                data = new List<int> { 106, 107, 111, 133, 221, 767, 1766 }
            });

            var viewModel = new HomeIndexViewModel
            {
                ChartDatas = allChartData
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}