using Homies.Models.Type;

namespace Homies.Services.Contracts
{
    public interface ITypeService
    {
        Task<IEnumerable<TypeViewModel>> GetAllAsync();
    }
}
