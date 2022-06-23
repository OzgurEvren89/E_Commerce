using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.BrandToCategory
{
    public class BrandToCategoryRepository : Repository<EF.BrandToCategory>, IBrandToCategoryRepository
    {
        private readonly DataContext _dataContext;
        public BrandToCategoryRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
