using asp_pract.Domain.Entities;
using asp_pract.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_pract.Domain.Repositories.EntityFramework
{
    public class EFNewsItemRepository //: INewsItemRepository
    {
        private readonly AppDbContext context;
        public EFNewsItemRepository(AppDbContext context)
        {
            this.context = context;
        }
        //public IQueryable<NewsItem> GetNewsItems()
        //{
        //    return context.NewsItems;
        //}
        //public NewsItem GetNewsItemById(Guid id)
        //{
        //    return context.NewsItems.FirstOrDefault(x => x.Id == id);
        //}
        //public void SaveNewsItem(NewsItem entity)
        //{
        //    if (entity.Id == default)
        //        context.Entry(entity).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Added;
        //    else
        //        context.Entry(entity).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        //    context.SaveChanges();
        //}
        //public void DeleteNewsItem(Guid id)
        //{
        //    context.NewsItems.Remove(new NewsItem() { Id = id });
        //    context.SaveChanges();
        //}
    }
}
