using Proje.Core.Repository;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.Currency
{
    public interface ICurrencyRepository : IRepository<EF.Currency>
    {
    }
}
