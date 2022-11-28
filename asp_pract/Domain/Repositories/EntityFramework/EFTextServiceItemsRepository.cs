using asp_pract.Domain.Entities;
using asp_pract.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace asp_pract.Domain.Repositories.EntityFramework
{
    public class EFTextServiceItemsRepository : IServiceItemsRepository
    {
        private readonly AppDbContext context;
        public EFTextServiceItemsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<ServiceItem> GetServiceItems()
        {
            return context.ServiceItems;
        }
        public ServiceItem GetServiceItemById(Guid id)
        {
            return context.ServiceItems.FirstOrDefault(x => x.Id == id);
        }
        public void SaveServiceItem(ServiceItem entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Added;
            else
                context.Entry(entity).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteServiceItem(Guid id)
        {
            context.ServiceItems.Remove(new ServiceItem() { Id = id });
            context.SaveChanges();
        }
    }
}
