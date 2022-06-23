using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.PaymentGateway
{
    public class PaymentGatewayRepository : Repository<EF.PaymentGateway>, IPaymentGatewayRepository
    {
        private readonly DataContext _dataContext;
        public PaymentGatewayRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;           
        }
    }
}
