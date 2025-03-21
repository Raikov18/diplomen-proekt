namespace diplomen_proekt.Models
{
    public class PizzaIngredient
    {
        public int PizzaId { get; set; }
        public int IngredientId {  get; set; }
        public virtual Pizza Pizza { get; set; }
        public virtual Ingredient  Ingredients { get; set; }
    }
}
