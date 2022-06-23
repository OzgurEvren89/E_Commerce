using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.ProductImage
{
    public class ProductImageRepository : Repository<EF.ProductImage>, IProductImageRepository
    {
        private readonly DataContext _dataContext;
        public ProductImageRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;

        }
    }
}
