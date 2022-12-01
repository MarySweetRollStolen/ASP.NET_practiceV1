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
    public class NewsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnviroment;
        public NewsController(DataManager dataManager, IWebHostEnvironment hostingEnviroment)
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
            var entity = dataManager.NewsItems.GetNewsItemById(id);
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
                //model.UprovedByAdmin = true;
                dataManager.NewsItems.SaveNewsItem(model);
                return RedirectToAction(nameof(NewsController.Index), nameof(NewsController).CutController());
            }
            return View(model);
        }


        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckTitle(string title)
        {
            foreach (NewsItem news in dataManager.NewsItems.GetNewsItems())
            {
                if(news.UprovedByAdmin == true)
                if (title == news.Title)
                    return Json(false);
            }
            return Json(true);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.NewsItems.DeleteNewsItem(id);
            return RedirectToAction(nameof(NewsController.Index), nameof(NewsController).CutController());
        }
    }
}
