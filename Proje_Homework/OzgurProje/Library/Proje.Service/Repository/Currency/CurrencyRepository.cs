using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.Currency
{
    public class CurrencyRepository : Repository<EF.Currency>, ICurrencyRepository
    {
        private readonly DataContext _dataContext;
        public CurrencyRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
