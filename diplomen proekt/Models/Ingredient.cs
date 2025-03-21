using System.Collections;

namespace diplomen_proekt.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            PizzaIngredients=new List<PizzaIngredient>();
        }
        public int Id {  get; set; }
        public string Name { get; set; }   
        public string Picture { get; set; }
        public int CaloriesPer100g { get; set; }
        public virtual ICollection<PizzaIngredient> PizzaIngredients {  get; set; }
    }
}
