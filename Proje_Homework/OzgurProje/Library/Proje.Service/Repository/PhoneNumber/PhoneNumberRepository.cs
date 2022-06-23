using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.PhoneNumber
{
    public class PhoneNumberRepository : Repository<EF.PhoneNumber>, IPhoneNumberRepository
    {
        private readonly DataContext _dataContext;
        public PhoneNumberRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
