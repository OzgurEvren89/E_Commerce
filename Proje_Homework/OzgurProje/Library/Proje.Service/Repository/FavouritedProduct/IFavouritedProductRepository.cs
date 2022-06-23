using Proje.Core.Repository;
using EF = Proje.Model.Entities;


namespace Proje.Service.Repository.FavouritedProduct
{
    public interface IFavouritedProductRepository : IRepository<EF.FavouritedProduct>
    {
    }
}
