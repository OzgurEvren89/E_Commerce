using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.Brand
{
    public class BrandRepository : Repository<EF.Brand>, IBrandRepository
    {
        private readonly DataContext _dataContext;
        public BrandRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
