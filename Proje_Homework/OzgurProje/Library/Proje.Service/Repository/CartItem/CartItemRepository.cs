using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.CartItem
{
    public class CartItemRepository : Repository<EF.CartItem>, ICartItemRepository
    {
        private readonly DataContext _dataContext;
        public CartItemRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
