using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.Distributor
{
    public class DistributorRepository : Repository<EF.Distributor>, IDistributorRepository
    {
        private readonly DataContext _dataContext;
        public DistributorRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
