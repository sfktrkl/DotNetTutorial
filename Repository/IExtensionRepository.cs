using System.Collections.Generic;
using System.Threading.Tasks;
using Tutorial.Models;

namespace Tutorial.Repository
{
    public interface IExtensionRepository
    {
        Task<List<ExtensionModel>> GetLanguages();
    }
}