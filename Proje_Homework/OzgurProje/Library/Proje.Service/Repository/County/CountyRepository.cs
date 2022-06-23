using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.County
{
    public class CountyRepository : Repository<EF.County>, ICountyRepository
    {
        private readonly DataContext _dataContext;
        public CountyRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
