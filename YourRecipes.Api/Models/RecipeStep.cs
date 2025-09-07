using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourRecipes.Api.Models;

public class RecipeStep
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(300)]
    public string Description { get; set; }
    
    public int StepNumber { get; set; }
    
    [ForeignKey(nameof(Recipe))]
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
}