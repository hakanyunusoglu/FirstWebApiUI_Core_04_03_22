using FirstWebApiUI.Models;
using FirstWebApiUI_Core_04_03_22.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FirstWebApiUI_Core_04_03_22.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {           
            return View();
        }

        public IActionResult Privacy()
        {
            List<ProductDto> resultlist = new List<ProductDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44315/api/");
                var responseTalk = client.GetAsync("Product/LoadProductList");
                responseTalk.Wait();

                var result = responseTalk.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var products = readTask.Result;
                    resultlist = JsonConvert.DeserializeObject<List<ProductDto>>(products);
                }
            }
            return View(resultlist);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
