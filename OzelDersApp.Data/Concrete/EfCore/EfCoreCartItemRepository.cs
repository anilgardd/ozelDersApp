using Microsoft.EntityFrameworkCore;
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
    public class EfCoreCartItemRepository : EfCoreGenericRepository<CartItem>, ICartItemRepository
    {
        public EfCoreCartItemRepository(OzelDersContext _appContext) : base(_appContext)
        {
        }

        OzelDersContext AppContext
        {
            get { return _dbContext as OzelDersContext; }
        }

        public async Task ChangeAmountAsync(CartItem cartItem, int amount)
        {
            cartItem.Amount = amount;
            AppContext.CartItems.Update(cartItem);
            await AppContext.SaveChangesAsync();
        }

        public void ClearCart(int cartId)
        {
            AppContext
                .CartItems
                .Where(ci => ci.CartId == cartId)
                .ExecuteDelete();
        }
    }
}
