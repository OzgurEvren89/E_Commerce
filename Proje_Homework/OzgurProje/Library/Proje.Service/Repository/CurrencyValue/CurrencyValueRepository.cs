using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.CurrencyValue
{
    public class CurrencyValueRepository : Repository<EF.CurrencyValue>, ICurrencyValueRepository
    {
        private readonly DataContext _dataContext;
        public CurrencyValueRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
