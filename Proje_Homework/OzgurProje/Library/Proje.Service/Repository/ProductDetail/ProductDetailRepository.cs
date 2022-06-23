using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.ProductDetail
{
    public class ProductDetailRepository : Repository<EF.ProductDetail>, IProductDetailRepository
    {
        private readonly DataContext _dataContext;
        public ProductDetailRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
