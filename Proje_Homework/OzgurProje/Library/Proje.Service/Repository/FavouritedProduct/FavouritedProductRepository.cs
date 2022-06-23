using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.FavouritedProduct
{
    public class FavouritedProductRepository : Repository<EF.FavouritedProduct>, IFavouritedProductRepository
    {
        private readonly DataContext _dataContext;
        public FavouritedProductRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
