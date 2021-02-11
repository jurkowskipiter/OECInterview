using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobInterviewOEC.Services
{
    public interface IAtlasDataRepository
    {
        Task<IList<AtlasData>> GetAll(string sortOrder, int pageNumber);
        Task<bool> Any();
        Task Add(AtlasData atlasData);
        Task SaveChanges();
    }
}
