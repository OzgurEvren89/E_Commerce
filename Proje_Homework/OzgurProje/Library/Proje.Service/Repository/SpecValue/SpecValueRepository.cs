using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.SpecValue
{
    public class SpecValueRepository : Repository<EF.SpecValue>, ISpecValueRepository
    {
        private readonly DataContext _dataContext;
        public SpecValueRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;

        }
    }
}
