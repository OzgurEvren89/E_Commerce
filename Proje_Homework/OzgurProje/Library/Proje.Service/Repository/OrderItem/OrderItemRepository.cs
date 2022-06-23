using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.OrderItem
{
    public class OrderItemRepository : Repository<EF.OrderItem>, IOrderItemRepository
    {
        private readonly DataContext _dataContext;
        public OrderItemRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
