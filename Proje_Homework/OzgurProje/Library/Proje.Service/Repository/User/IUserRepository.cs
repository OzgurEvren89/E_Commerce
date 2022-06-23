using Proje.Core.Repository;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.User
{
    public interface IUserRepository : IRepository<EF.User>
    {

    }
}
