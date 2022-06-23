using Proje.Web.UI.Areas.Admin.Models.CartItemViewModels;
using Proje.Web.UI.Areas.Admin.Models.CartViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Infrasructure.Helpers
{
    public class CartHelper
    {
        public CartViewModel Cart;

        public CartHelper(CartViewModel cart)
        {
            Cart = cart;
        }



        #region Sepete_Ekle
        public void AddCart(CartItemViewModel item)
        {
            if (!Cart.CartItems.Any(x => x.Id == item.Id))
                Cart.CartItems.Add(item);
            else
                this.IncreaseCart(item.Id);

        }
        #endregion

        #region Sepet_Arttir
        public void IncreaseCart(Guid id)
        {
            CartItemViewModel cartItem = Cart.CartItems.FirstOrDefault(x => x.Id == id);
            cartItem.Quantity++;
        }
        #endregion

        #region Sepet_Azalt
        public void DecreaseCart(Guid id)
        {
            CartItemViewModel cartItem = Cart.CartItems.FirstOrDefault(x => x.Id == id);
            cartItem.Quantity--;
            if (cartItem.Quantity <= 0)
                this.RemoveCart(id);
        }
        #endregion

        #region Sepet_Sil
        public void RemoveCart(Guid id) => Cart.CartItems.Remove(Cart.CartItems.FirstOrDefault(x => x.Id == id));
        #endregion
    }
}
