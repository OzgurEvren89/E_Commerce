using Proje.Core.Repository;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.Category
{
    public interface ICategoryRepository : IRepository<EF.Category>
    {
    }
}
