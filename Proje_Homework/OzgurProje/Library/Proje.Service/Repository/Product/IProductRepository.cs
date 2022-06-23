using Proje.Core.Repository;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.Product
{
    public interface IProductRepository : IRepository<EF.Product>
    {
    }
}
