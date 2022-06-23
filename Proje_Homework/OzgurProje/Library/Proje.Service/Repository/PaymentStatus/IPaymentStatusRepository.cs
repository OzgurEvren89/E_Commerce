using Proje.Core.Repository;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.PaymentStatus
{
    public interface IPaymentStatusRepository : IRepository<EF.PaymentStatus>
    {

    }
}
