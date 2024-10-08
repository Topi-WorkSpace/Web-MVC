﻿namespace BookShoppingCartMvcUI.Repositories
{
    public interface ICartRepository
    {
        Task<int> AddItem(int productId, int qty);
        Task<int> RemoveItem(int bookId);
        Task<ShoppingCart> GetUserCart();
        Task<int> GetCartItemCount(string userId = "");
        Task<ShoppingCart> GetCart(string userId);
        Task<bool> DoCheckout();
    }
}