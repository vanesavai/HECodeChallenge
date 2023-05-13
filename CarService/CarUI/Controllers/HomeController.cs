using CarUI.Controllers.Classes;
using CarUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Diagnostics;

namespace CarUI.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client = new HttpClient( );
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task< IActionResult> Index()
        {
            
            client.BaseAddress = new Uri("https://localhost:7115/Car/GetListOfCars");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            List<Car> cardemo = await GetCars();

            IndexViewModel model = new IndexViewModel() { CarList = cardemo };

            return View(model);
        }









        public async Task<List<Car>> GetCars()
        {

            HttpResponseMessage x = await client.GetAsync("/Car/GetListOfCars");
            if (x.IsSuccessStatusCode) { 
                var cars = await x.Content.ReadAsAsync< List<Car> >(); 
                return cars;
            }
            return new List<Car>();
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