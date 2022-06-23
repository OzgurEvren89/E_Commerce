using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.Category
{
    public class CategoryRepository : Repository<EF.Category>, ICategoryRepository
    {
        private readonly DataContext _dataContext;
        public CategoryRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
            //_dataContext.Set<EF.Post>().Add(new EF.Post());

        }



    }
}
