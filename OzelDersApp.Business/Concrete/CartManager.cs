using OzelDersApp.Business.Abstract;
using OzelDersApp.Data.Abstract;
using OzelDersApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersApp.Business.Concrete
{
    public class CartManager : ICartService
    {
        private ICartRepository _cartRepository;

        public CartManager(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task AddToCart(string userId, int advertId, int amount)
        {
            await _cartRepository.AddToCart(userId, advertId, amount);

        }

        public async Task<Cart> GetCartByUserId(string userId)
        {
            return await _cartRepository.GetCartByUserId(userId);
        }
        public async Task InitializeCart(string userId)
        {
            await _cartRepository.CreateAsync(new Cart { UserId = userId });
        }
    }
}
