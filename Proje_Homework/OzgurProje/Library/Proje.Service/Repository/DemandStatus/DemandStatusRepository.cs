using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.DemandStatus
{
    public class DemandStatusRepository : Repository<EF.DemandStatus>, IDemandStatusRepository
    {
        private readonly DataContext _dataContext;
        public DemandStatusRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
