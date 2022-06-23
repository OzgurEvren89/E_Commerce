using Proje.Core.Repository;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.Payment
{
    public interface IPaymentRepository : IRepository<EF.Payment>
    {
    }
}
