using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public TestModel NewTestModel = new TestModel();
        public string Test = "Meow";
        public int SomeNum = 0;
    
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
    
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetModelProps()
        {
            var props = NewTestModel.GetType().GetProperties()
                .Select(p => new
                {
                    Name = p.Name,
                    Type = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType
                })
                .ToDictionary(p => p.Name, p => p.Type == typeof(int) ? "number" : p.Type.Name.ToLower());
            
            string modelAsJson = JsonConvert.SerializeObject(props);
            
            return Json(modelAsJson);
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