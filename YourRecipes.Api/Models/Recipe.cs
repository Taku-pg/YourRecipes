using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace YourRecipes.Api.Models;

public class Recipe
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; }
    
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public ICollection<IngredientBase> Ingredients { get; set; }
    public ICollection<RecipeStep> MethodSteps { get; set; }
    public ICollection<Recipe> Recipes { get; set; }
    
    
}