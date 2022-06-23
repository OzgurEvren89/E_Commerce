using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.SpecToProduct
{
    public class SpecToProductRepository : Repository<EF.SpecToProduct>, ISpecToProductRepository
    {
        private readonly DataContext _dataContext;
        public SpecToProductRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;

        }
    }
}
