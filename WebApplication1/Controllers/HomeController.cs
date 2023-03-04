using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public TestModel NewTestModel = new TestModel();
        public string Test = "Meow";
        public int SomeNum = 0;
    
        // public HomeController()
        // {
        //     
        // }
    
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetModelProps()
        {
            TestModel model = new TestModel();

            var props = model.GetType().GetProperties()
                .Select(p => new {
                    p.Name,
                    Type = GetTypeName(p.PropertyType)
                })
                .ToDictionary(p => p.Name, p => p.Type);

            string json = JsonConvert.SerializeObject(props);
            
            return Json(json);
        }

        public static string GetTypeName(Type type)
        {
            if (type == typeof(int) || type == typeof(double) || type == typeof(float)
                || type == typeof(decimal) || type == typeof(long) || type == typeof(short)
                || type == typeof(byte) || type == typeof(uint) || type == typeof(ulong)
                || type == typeof(ushort) || type == typeof(sbyte))
            {
                return "number";
            }
            else if (type == typeof(bool))
            {
                return "boolean";
            }
            else if (type == typeof(DateTime))
            {
                return "Date";
            }
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // Handle nullable value types
                Type? underlyingType = Nullable.GetUnderlyingType(type);
                if (underlyingType != null)
                {
                    return GetTypeName(underlyingType);
                }
            }

            return type.Name.ToLower();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}