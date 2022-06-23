using Proje.Core.Repository;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.OrderItem
{
    public interface IOrderItemRepository : IRepository<EF.OrderItem>
    {

    }
}
