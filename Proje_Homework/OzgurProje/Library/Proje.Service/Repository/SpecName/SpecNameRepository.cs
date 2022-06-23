using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.SpecName
{
    public class SpecNameRepository : Repository<EF.SpecName>, ISpecNameRepository
    {
        private readonly DataContext _dataContext;
        public SpecNameRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;           

        }
    }
}
