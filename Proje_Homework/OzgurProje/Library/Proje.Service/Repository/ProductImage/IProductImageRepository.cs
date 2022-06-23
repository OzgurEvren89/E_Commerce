using Proje.Core.Repository;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.ProductImage
{
    public interface IProductImageRepository : IRepository<EF.ProductImage>
    {
    }
}
