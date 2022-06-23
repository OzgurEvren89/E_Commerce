using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.OrderStatus
{
    public class OrderStatusRepository : Repository<EF.OrderStatus>, IOrderStatusRepository
    {
        private readonly DataContext _dataContext;
        public OrderStatusRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
