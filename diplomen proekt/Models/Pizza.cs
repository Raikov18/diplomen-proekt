namespace diplomen_proekt.Models
{
    public class Pizza
    {
        public Pizza()
        {
            Ratings=new List<Rating>();
            PizzaIngredients=new List<PizzaIngredient>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrls { get; set; }
        public string[] Images => ImageUrls.Split("/", StringSplitOptions.RemoveEmptyEntries);
        public decimal Price {  get; set; }
        public decimal Diameter { get; set; }
        public int Portions {  get; set; }
        public string Description {  get; set; }
        public  ICollection<Rating> Ratings {  get; set; }
        public ICollection<PizzaIngredient> PizzaIngredients { get; set; }


    }
}
