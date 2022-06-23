using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.Cart
{
    public class CartRepository : Repository<EF.Cart>, ICartRepository
    {
        private readonly DataContext _dataContext;
        public CartRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
            //_dataContext.Set<EF.Post>().Add(new EF.Post());
        }
    }
}
