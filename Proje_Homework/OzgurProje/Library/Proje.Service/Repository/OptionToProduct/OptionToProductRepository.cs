using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.OptionToProduct
{
    public class OptionToProductRepository : Repository<EF.OptionToProduct>, IOptionToProductRepository
    {
        private readonly DataContext _dataContext;
        public OptionToProductRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
