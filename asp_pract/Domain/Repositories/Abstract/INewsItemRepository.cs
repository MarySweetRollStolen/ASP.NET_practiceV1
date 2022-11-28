using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_pract.Domain.Entities;

namespace asp_pract.Domain.Repositories.Abstract
{
    public interface INewsItemRepository
    {
        IQueryable<NewsItem> GetNewsItems();
        NewsItem GetNewsItemById(Guid id);
        void SaveNewsItem(NewsItem entity);
        void DeleteNewsItem(Guid id);
    }
}
