using Proje.Core.Repository;
using EF = Proje.Model.Entities;


namespace Proje.Service.Repository.PaymentType
{
    public interface IPaymentTypeRepository : IRepository<EF.PaymentType>
    {
    }
}
