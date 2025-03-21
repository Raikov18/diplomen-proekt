using diplomen_proekt.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace diplomen_proekt.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<PizzaIngredient> PizzaIngredients { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Композитен ключ за PizzaIngredients
            modelBuilder.Entity<PizzaIngredient>()
                .HasKey(pi => new { pi.PizzaId, pi.IngredientId });

            // Връзка между PizzaIngredients и Pizza
            modelBuilder.Entity<PizzaIngredient>()
                .HasOne(pi => pi.Pizza)
                .WithMany(p => p.PizzaIngredients)  // Предполагаемото свойство в Pizza
                .HasForeignKey(pi => pi.PizzaId);

            // Връзка между PizzaIngredients и Ingredient
            modelBuilder.Entity<PizzaIngredient>()
                .HasOne(pi => pi.Ingredients)
                .WithMany(i => i.PizzaIngredients)  // Предполагаемото свойство в Ingredient
                .HasForeignKey(pi => pi.IngredientId);
            
        }
       
        }

    }



