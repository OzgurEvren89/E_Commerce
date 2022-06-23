using Proje.Core.Repository;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.County
{
    public interface ICountyRepository : IRepository<EF.County>
    {
    }
}
