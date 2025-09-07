using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YourRecipes.Api.Models;

//[PrimaryKey(nameof(Recipe), nameof(Food))]
public abstract class IngredientBase
{
    [Key]
    public int Id { get; set; }
    [ForeignKey(nameof(Recipe))]
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    
    [Precision(6,1)]
    public double Amount { get; set; }
    public string Unit { get; set; }
}

public class FoodIngredient : IngredientBase
{
    [ForeignKey(nameof(Food))]
        public int FoodId { get; set; }
        public Food Food { get; set; }
}

public class RecipeIngredient : IngredientBase
{
    [ForeignKey(nameof(Recipe))]
    public int SubRecipeId { get; set; }
    public Recipe SubRecipe { get; set; }
}