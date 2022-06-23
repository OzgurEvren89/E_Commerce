using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.SpecGroup
{
    public class SpecGroupRepository : Repository<EF.SpecGroup>, ISpecGroupRepository
    {
        private readonly DataContext _dataContext;
        public SpecGroupRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
           
        }
    }
}
