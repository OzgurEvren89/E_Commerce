using Microsoft.EntityFrameworkCore;

namespace Proje.Core.Map
{
    public interface IEntityBuilder
    {
        void Build(ModelBuilder builder);
    }
}
