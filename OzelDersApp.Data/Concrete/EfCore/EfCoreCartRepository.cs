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
    public class EfCoreCartRepository : EfCoreGenericRepository<Cart>, ICartRepository
    {
        public EfCoreCartRepository(OzelDersContext _appContext) : base(_appContext)
        {
        }
        OzelDersContext AppContext
        {
            get { return _dbContext as OzelDersContext; }
        }

        public async Task AddToCart(string userId, int advertId, int amount)
        {
            var cart = await GetCartByUserId(userId);
            if (cart != null)
            {
                var index = cart.CartItems.FindIndex(ci => ci.AdvertId == advertId);
                if (index < 0)
                {
                    cart.CartItems.Add(new CartItem
                    {
                        AdvertId = advertId,
                        CartId = cart.Id,
                        Amount = amount
                    });
                }
                else
                {
                    cart.CartItems[index].Amount += amount;
                }
                AppContext.Carts.Update(cart);
                await AppContext.SaveChangesAsync();
            }
        }

        public async Task<Cart> GetCartByUserId(string userId)
        {
            return await AppContext
                 .Carts
                 .Include(c => c.CartItems)
                 .ThenInclude(ci => ci.Advert)
                 .ThenInclude(ci=> ci.Teacher)
                 .ThenInclude(ci=> ci.TeacherBranches)
                 .ThenInclude(ci=> ci.Branch)
                 .Include(c => c.CartItems)
                 .ThenInclude(ci => ci.Advert)
                 .ThenInclude(ci => ci.Teacher)
                 .ThenInclude(ci => ci.User)
                 .ThenInclude(ci => ci.Image)
                
                 .FirstOrDefaultAsync(c => c.UserId == userId);
        }


    }
}
