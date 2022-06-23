using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.Options
{
    public class OptionsRepository : Repository<EF.Options>, IOptionsRepository
    {
        private readonly DataContext _dataContext;
        public OptionsRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
