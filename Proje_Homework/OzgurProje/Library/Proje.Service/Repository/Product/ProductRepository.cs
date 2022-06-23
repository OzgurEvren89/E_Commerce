using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.Product
{
    public class ProductRepository : Repository<EF.Product>, IProductRepository
    {
        private readonly DataContext _dataContext;
        public ProductRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
           
        }
    }
}
