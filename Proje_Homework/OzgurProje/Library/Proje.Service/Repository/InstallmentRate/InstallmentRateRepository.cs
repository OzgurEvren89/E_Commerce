using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.InstallmentRate
{
    public class InstallmentRateRepository : Repository<EF.InstallmentRate>, IInstallmentRateRepository
    {
        private readonly DataContext _dataContext;
        public InstallmentRateRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
