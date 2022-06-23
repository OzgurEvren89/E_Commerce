using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.MemberAddress
{
    public class MemberAddressRepository : Repository<EF.MemberAddress>, IMemberAddressRepository
    {
        private readonly DataContext _dataContext;
        public MemberAddressRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
