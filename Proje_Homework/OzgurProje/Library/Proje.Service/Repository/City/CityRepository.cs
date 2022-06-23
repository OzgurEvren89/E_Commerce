using Proje.Model.Context;
using Proje.Service.Repository.Base;
using EF = Proje.Model.Entities;

namespace Proje.Service.Repository.City
{
    public class CityRepository : Repository<EF.City>, ICityRepository
    {
        private readonly DataContext _dataContext;
        public CityRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
            //_dataContext.Set<EF.Post>().Add(new EF.Post());
        }
    }
}
