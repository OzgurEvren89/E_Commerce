using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.PhoneNumberType
{
    public class PhoneNumberTypeRepository : Repository<EF.PhoneNumberType>, IPhoneNumberTypeRepository
    {
        private readonly DataContext _dataContext;
        public PhoneNumberTypeRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
