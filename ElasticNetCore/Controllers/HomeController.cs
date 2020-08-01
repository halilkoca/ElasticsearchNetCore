using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ElasticNetCore.Models;
using ElasticNetCore.Services;
using ElasticNetCore.Entities;

namespace ElasticNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IElasticsearchService _elasticsearch;

        public HomeController(

            ILogger<HomeController> logger
            , IElasticsearchService elasticsearch
            )
        {
            _logger = logger;
            _elasticsearch = elasticsearch;
        }

        public async Task<IActionResult> Index()
        {

            await _elasticsearch.ChekIndex("product");

            // test insert
            //await _elasticsearch.InsertDocument("product", new Product { ImageUrl = "https://www.cihatayaz.com/wp-content/uploads/2016/06/hevesli-kitap-okumak.jpg", Name = "Kürk Mantolu Madonna", Price = 25.5 });

            var model = await GetItems();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([ModelBinder] List<Product> products)
        {

            if (ModelState.IsValid)
            {
                await _elasticsearch.InsertDocuments("product", products);
            }

            return RedirectToAction("Index");
        }

        private async Task<List<Product>> GetItems()
        {
            await Task.Delay(500);
            return await _elasticsearch.GetDocuments("product");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
