﻿using Microsoft.EntityFrameworkCore;
using OzelDersApp.Data.Abstract;
using OzelDersApp.Data.Concrete.EfCore.Context;
using OzelDersApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersApp.Data.Concrete.EfCore
{
    public class EfCoreOrderRepository : EfCoreGenericRepository<Order>, IOrderRepository
    {
        public EfCoreOrderRepository(OzelDersContext _appContext) : base(_appContext)
        {
        }
        OzelDersContext AppContext
        {
            get { return _dbContext as OzelDersContext;}
        }

        public async Task<List<Order>> GetAllOrdersAsync(string userId = null, bool dateSort = false)
        {
            var orders = AppContext
                .Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi=> oi.Advert)
                .ThenInclude(oi=> oi.Branch)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Advert)
                .ThenInclude(oi => oi.Teacher)
                .ThenInclude(oi => oi.User)
                .ThenInclude(oi => oi.Image)
                .AsQueryable();
            if (dateSort)
            {
                orders = orders.OrderByDescending(o => o.OrderDate);
            }
            else
            {
                orders = orders.OrderBy(o => o.OrderDate);
            }
            if (!String.IsNullOrEmpty(userId))
            {
                orders = orders.Where(o => o.UserId == userId);    
            }
       
            return await orders.ToListAsync();
        }

        public async Task<List<Order>> SearchOrderByUser(string keyword, bool dateSort = false)
        {
            var orders = AppContext
                .Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Advert)
                .ThenInclude(oi => oi.Teacher)
                .ThenInclude(oi => oi.User)
                .ThenInclude(oi => oi.Image)
                .Where(o=> o.NormalizedName.Contains(keyword))
                .AsQueryable();
            if (dateSort)
            {
                orders = orders.OrderByDescending(o => o.OrderDate);
            }
            else
            {
                orders = orders.OrderBy(o => o.OrderDate);
            }
            return await orders.ToListAsync();
        }
    }
}
