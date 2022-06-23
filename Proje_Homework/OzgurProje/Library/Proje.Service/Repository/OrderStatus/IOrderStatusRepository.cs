using Proje.Core.Repository;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.OrderStatus
{
    public interface IOrderStatusRepository : IRepository<EF.OrderStatus>
    {

    }
}
