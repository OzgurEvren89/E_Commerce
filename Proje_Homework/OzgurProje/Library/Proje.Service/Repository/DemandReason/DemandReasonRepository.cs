using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.DemandReason
{
    public class DemandReasonRepository : Repository<EF.DemandReason>, IDemandReasonRepository
    {
        private readonly DataContext _dataContext;
        public DemandReasonRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
