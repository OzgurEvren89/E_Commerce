using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.OptionGroup
{
    public class OptionGroupRepository : Repository<EF.OptionGroup>, IOptionGroupRepository
    {
        private readonly DataContext _dataContext;
        public OptionGroupRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
