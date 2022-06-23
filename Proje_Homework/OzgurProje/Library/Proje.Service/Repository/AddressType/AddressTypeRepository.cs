using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.AddressType
{
    public class AddressTypeRepository : Repository<EF.AddressType>, IAddressTypeRepository
    {
        private readonly DataContext _dataContext;
        public AddressTypeRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
