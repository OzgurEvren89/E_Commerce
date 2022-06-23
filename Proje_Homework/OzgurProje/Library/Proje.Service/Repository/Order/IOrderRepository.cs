using Proje.Core.Repository;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.Order
{
    public interface IOrderRepository : IRepository<EF.Order>
    {
    }
}
