using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.User
{
    public class UserRepository : Repository<EF.User>, IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
