using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.ShippingCompany
{
    public class ShippingCompanyRepository : Repository<EF.ShippingCompany>, IShippingCompanyRepository
    {
        private readonly DataContext _dataContext;
        public ShippingCompanyRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
