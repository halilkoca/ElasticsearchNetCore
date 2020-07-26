using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ElasticNetCore.Models;
using ElasticNetCore.Services;

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

        public IActionResult Index()
        {

            _elasticsearch.ChekIndex("product");

            return View();
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
