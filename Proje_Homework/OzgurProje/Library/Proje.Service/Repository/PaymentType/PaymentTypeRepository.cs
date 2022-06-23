using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;


namespace Proje.Service.Repository.PaymentType
{
    public class PaymentTypeRepository : Repository<EF.PaymentType>, IPaymentTypeRepository
    {
        private readonly DataContext _dataContext;
        public PaymentTypeRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
