using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.ProductComment
{
    public class ProductCommentRepository : Repository<EF.ProductComment>, IProductCommentRepository
    {
        private readonly DataContext _dataContext;
        public ProductCommentRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
