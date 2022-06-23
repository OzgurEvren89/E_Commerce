using Proje.Core.Repository;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.CartItem
{
    public interface ICartItemRepository : IRepository<EF.CartItem>
    {
    }
}
