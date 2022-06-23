using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.PaymentStatus
{
    public class PaymentStatusRepository : Repository<EF.PaymentStatus>, IPaymentStatusRepository
    {
        private readonly DataContext _dataContext;
        public PaymentStatusRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
