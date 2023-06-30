using Homies.Data;
using Homies.Models.Type;
using Homies.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Homies.Services
{
    public class TypeService : ITypeService
    {
        private readonly HomiesDbContext homiesDbContext;
        public TypeService(HomiesDbContext homiesDbContext)
        {
            this.homiesDbContext = homiesDbContext;
        }
        public async Task<IEnumerable<TypeViewModel>> GetAllAsync()
        {
            IEnumerable<TypeViewModel> list = await homiesDbContext.Types
                .Select(t => new TypeViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToListAsync();
            return list;
        }
    }
}
