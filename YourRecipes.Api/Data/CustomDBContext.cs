using Microsoft.EntityFrameworkCore;
using YourRecipes.Api.Models;

namespace YourRecipes.Api.Data;

public class CustomDBContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeStep> MethodSteps { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<IngredientBase> Ingredients { get; set; }
    public DbSet<Food> Foods { get; set; }
    
    
    protected CustomDBContext()
    {
    }

    public CustomDBContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //TPH
        modelBuilder.Entity<IngredientBase>()
            .HasDiscriminator<string>("IngredientType")
            .HasValue<FoodIngredient>("Food")
            .HasValue<RecipeIngredient>("Recipe");
        
        modelBuilder.Entity<User>().HasData(new List<User>
        {
            new User { Id = 1, Name = "John", Email = "john@gmail.com", Password = "password" },
            new User { Id = 2, Name = "Jasmin", Email = "jasmin@gmail.com", Password = "password" },
        });

        modelBuilder.Entity<Category>().HasData(new List<Category>
        {
            new Category { Id = 1, Name = "Appetiser", UserId = 1},
            new Category { Id = 2, Name = "Main Dish", UserId = 1 },
            new Category { Id = 3, Name = "Sauce", UserId = 1 },
            new Category { Id = 4, Name = "Sweets", UserId = 2 },
            new Category { Id = 5, Name = "Breakfast", UserId = 2 },
        });
        
        modelBuilder.Entity<Recipe>().HasData(new List<Recipe>
        {
            new Recipe { Id = 1, Name = "Carpaccio", CategoryId = 1},
            new Recipe { Id = 2, Name = "White Sauce", CategoryId = 3},
            new Recipe { Id = 3, Name = "Meat Sauce", CategoryId = 3},
            new Recipe { Id = 4, Name = "Lasagna", CategoryId = 2},
            new Recipe { Id = 5, Name = "Cheese Cake", CategoryId = 4},
            new Recipe { Id = 6, Name = "Acai Bowl", CategoryId = 5},
        });

        modelBuilder.Entity<Food>().HasData(new List<Food>
        {
            new Food { Id = 1, Name = "Salmon", UserId = 1},
            new Food { Id = 2, Name = "Olive", UserId = 1 },
            new Food { Id = 3, Name = "Olive Oil", UserId = 1 },
            new Food { Id = 4, Name = "Salt", UserId = 1 },
            new Food { Id = 5, Name = "Pepper", UserId = 1 },
            new Food { Id = 6, Name = "Milk", UserId = 1 },
            new Food { Id = 7, Name = "Flour", UserId = 1 },
            new Food { Id = 8, Name = "Minced Meat", UserId = 1 },
            new Food { Id = 9, Name = "Canned Tomato", UserId = 1 },
            new Food { Id = 10, Name = "Sheet Pasta", UserId = 1 },
            new Food { Id = 11, Name = "Sugar", UserId = 2 },
            new Food { Id = 12, Name = "Flour", UserId = 2 },
            new Food { Id = 13, Name = "Cream Cheese", UserId = 2 }, 
            new Food { Id = 14, Name = "Heavy Cream", UserId = 2 },
            new Food { Id = 15, Name = "Acai Puree", UserId = 2 },
            new Food { Id = 16, Name = "Granola", UserId = 2 },
            new Food { Id = 17, Name = "Banana", UserId = 2 },
            new Food { Id = 18, Name = "Strawberry", UserId = 2 },
            new Food { Id = 19, Name = "Egg", UserId = 2 },
        });

        modelBuilder.Entity<FoodIngredient>().HasData(new List<FoodIngredient>
        {
            new FoodIngredient { Id = 1,RecipeId = 1, FoodId = 1, Amount = 100, Unit = "g"},
            new FoodIngredient { Id = 2, RecipeId = 1, FoodId = 2, Amount = 30, Unit = "g" },
            new FoodIngredient { Id = 3, RecipeId = 1, FoodId = 3, Amount = 15, Unit = "ml" },
            new FoodIngredient { Id = 4, RecipeId = 1, FoodId = 4, Amount = 1, Unit = "pinch" },
            new FoodIngredient { Id = 5, RecipeId = 1, FoodId = 5, Amount = 0.4, Unit = "g" },
            new FoodIngredient { Id = 6, RecipeId = 2, FoodId = 6, Amount = 300, Unit = "g" },
            new FoodIngredient { Id = 7, RecipeId = 2, FoodId = 7, Amount = 45, Unit = "g" },
            new FoodIngredient { Id = 8, RecipeId = 3, FoodId = 8, Amount = 300, Unit = "g" },
            new FoodIngredient { Id = 9, RecipeId = 3, FoodId = 9, Amount = 200, Unit = "g" },
            new FoodIngredient { Id = 10, RecipeId = 4, FoodId = 10, Amount = 200, Unit = "g" },
            new FoodIngredient { Id = 11, RecipeId = 5, FoodId = 11, Amount = 80, Unit = "g" },
            new FoodIngredient { Id = 12, RecipeId = 5, FoodId = 12, Amount = 200, Unit = "g" },
            new FoodIngredient { Id = 13, RecipeId = 5, FoodId = 13, Amount = 100, Unit = "g" },
            new FoodIngredient { Id = 14, RecipeId = 5, FoodId = 14, Amount = 100, Unit = "g" },
            new FoodIngredient { Id = 15, RecipeId = 6, FoodId = 15, Amount = 40, Unit = "g" },
            new FoodIngredient { Id = 16, RecipeId = 6, FoodId = 16, Amount = 30, Unit = "g" },
            new FoodIngredient { Id = 17, RecipeId = 6, FoodId = 17, Amount = 50, Unit = "g" },
            new FoodIngredient { Id = 18, RecipeId = 6, FoodId = 18, Amount = 30, Unit = "g" },
            new FoodIngredient { Id = 19, RecipeId = 5, FoodId = 19, Amount = 2, Unit = "" },
        });

        modelBuilder.Entity<RecipeIngredient>().HasData(new List<RecipeIngredient>
        {
            new RecipeIngredient{ Id = 19, RecipeId = 4, SubRecipeId = 2, Amount = 200, Unit = "g"},
            new RecipeIngredient{ Id = 20, RecipeId = 4, SubRecipeId = 3, Amount = 200, Unit = "g"},
        });

        modelBuilder.Entity<RecipeStep>().HasData(new List<RecipeStep>
        {
            new RecipeStep{ Id = 1, RecipeId = 1, StepNumber = 1, Description = "Slice a salmon"},
            new RecipeStep{ Id = 2, RecipeId = 1, StepNumber = 2, Description = "Chop olives"},
            new RecipeStep{ Id = 3, RecipeId = 1, StepNumber = 3, Description = "Mix sliced salmon, chopped olive and olive oil"},
            new RecipeStep{ Id = 4, RecipeId = 1, StepNumber = 4, Description = "Add salt and pepper"},
            new RecipeStep{ Id = 5, RecipeId = 2, StepNumber = 1, Description = "Put flour in a pan and warm it"},
            new RecipeStep{ Id = 6, RecipeId = 2, StepNumber = 2, Description = "Gradually add milk"},
            new RecipeStep{ Id = 7, RecipeId = 3, StepNumber = 1, Description = "Grill minced meat in a pot"},
            new RecipeStep{ Id = 8, RecipeId = 3, StepNumber = 2, Description = "Add a canned tomato"},
            new RecipeStep{ Id = 9, RecipeId = 4, StepNumber = 1, Description = "Layer meat sauce and white sauce with sheet pasta"},
            new RecipeStep{ Id = 10, RecipeId = 4, StepNumber = 2, Description = "Bake until the top gets golden brown"},
            new RecipeStep{ Id = 11, RecipeId = 5, StepNumber = 1, Description = "Mix soften cream cheese and sugar"},
            new RecipeStep{ Id = 12, RecipeId = 5, StepNumber = 2, Description = "Add eggs"},
            new RecipeStep{ Id = 13, RecipeId = 5, StepNumber = 3, Description = "Add flour"},
            new RecipeStep{ Id = 14, RecipeId = 5, StepNumber = 4, Description = "Bake with 170\u00b0C for 30 min"},
            new RecipeStep{ Id = 15, RecipeId = 6, StepNumber = 1, Description = "Mix all ingredients in a bowl"},
        });
    }
    
    
}