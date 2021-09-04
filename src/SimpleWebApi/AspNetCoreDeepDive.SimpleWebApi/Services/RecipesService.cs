using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDeepDive.SimpleWebApi.Services
{
    public record Recipe(string Title, string[] Ingredients, string[] Directions, byte Servings);
    
    public class RecipesService: IRecipesService
    {
        private IEnumerable<Recipe> Recipes { get; }

        public RecipesService()
        {
            Recipes = new List<Recipe>
            {
                new Recipe(
                    "Pudim de Leite Condensado", 
                    new String[]{"1 lata de leite condensado", "1 xícara de leite de vaca", "4 ovos inteiros"}, 
                    new String[]{"Bata todos os ingredientes no liquidificador e despeje na forma caramelizada.", "Leve para assar em banho-maria por 40 minutos.", "Desenforme e sirva"}, 
                    4
                )
            };
        }
        
        public Task<IEnumerable<Recipe>> GetAll() => Task.FromResult(Recipes?.AsEnumerable());
        public Task<Recipe> Get(string name) => Task.FromResult(Recipes.FirstOrDefault(x => x.Title == name));
    }
}