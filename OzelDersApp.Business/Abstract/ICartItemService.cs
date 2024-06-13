using OzelDersApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersApp.Business.Abstract
{
    public interface ICartItemService
    {
        Task ChangeAmountAsync(int cartItemId, int amount);
        Task<CartItem> GetByIdAsync(int id);
        void Delete(CartItem cartItem);
        void ClearCart(int cartId);
    }
}
