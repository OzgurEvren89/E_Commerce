using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.DistributorToProduct
{
    public class DistributorToProductRepository : Repository<EF.DistributorToProduct>, IDistributorToProductRepository
    {
        private readonly DataContext _dataContext;
        public DistributorToProductRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
