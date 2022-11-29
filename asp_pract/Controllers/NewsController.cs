using asp_pract.Domain;
using asp_pract.Domain.Entities;
using asp_pract.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using asp_pract.Service;
using Microsoft.AspNetCore.Hosting;

namespace asp_pract.Controllers
{
    public class NewsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnviroment;

        public NewsController(ILogger<HomeController> logger, DataManager dataManager, IWebHostEnvironment hostingEnviroment)
        {
            _logger = logger;
            this.dataManager = dataManager;
            this.hostingEnviroment = hostingEnviroment;
        }

        public IActionResult Index()
        {
            return View(dataManager.NewsItems.GetNewsItems());
        }

        public IActionResult Advise()
        {
            var entity = new NewsItem();
            return View(entity);

        }
        [HttpPost]
        public IActionResult Advise(NewsItem model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    model.TitleImagePath = (string)titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnviroment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                model.UprovedByAdmin = false;
                dataManager.NewsItems.SaveNewsItem(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
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
