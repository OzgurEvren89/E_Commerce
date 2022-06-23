using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.Payment
{
    public class PaymentRepository : Repository<EF.Payment>, IPaymentRepository
    {
        private readonly DataContext _dataContext;
        public PaymentRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
