using asp_pract.Domain;
using asp_pract.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using asp_pract.Service;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_pract.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsItemsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnviroment;
        public NewsItemsController(DataManager dataManager, IWebHostEnvironment hostingEnviroment)
        {
            this.dataManager = dataManager;
            this.hostingEnviroment = hostingEnviroment;
        }
        public IActionResult Index()
        {
            return View(dataManager.NewsItems.GetNewsItems());
        }

        public IActionResult Uprove(Guid id)
        {
            var entity =  dataManager.ServiceItems.GetServiceItemById(id);
            return View(entity);

        }

        [HttpPost]
        public IActionResult Uprove(NewsItem model, IFormFile titleImageFile)
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

                dataManager.NewsItems.SaveNewsItem(model);
                return RedirectToAction(nameof(NewsItemsController.Index), nameof(NewsItemsController).CutController());
            }
            return View(model);
        }


        [HttpPost]
        public JsonResult IsTitleUnique(NewsItem oneNews)
        {
            List<string> listTitle = null;
            foreach (NewsItem entity in dataManager.NewsItems.GetNewsItems())
            {
                listTitle.Add(entity.Title);
            }
            if (listTitle.Contains(oneNews.Title)) {
                return Json("Iм'я не унікальне");
            }
            return Json("Iм'я унікальне");
        }


        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.NewsItems.DeleteNewsItem(id);
            return RedirectToAction(nameof(NewsItemsController.Index), nameof(NewsItemsController).CutController());
        }
    }
}
