using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.OrderRefundDemand
{
    public class OrderRefundDemandRepository : Repository<EF.OrderRefundDemand>, IOrderRefundDemandRepository
    {
        private readonly DataContext _dataContext;
        public OrderRefundDemandRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
