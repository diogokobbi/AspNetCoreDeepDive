using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreDeepDive.SimpleWebApi.Services
{
    public interface IRecipesService
    {
        Task<IEnumerable<Recipe>> GetAll();
        Task<Recipe> Get(string name);
    }
}