using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.Order
{
    public class OrderRepository : Repository<EF.Order>, IOrderRepository
    {
        private readonly DataContext _dataContext;
        public OrderRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
