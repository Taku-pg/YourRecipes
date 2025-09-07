using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourRecipes.Api.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public virtual User User { get; set; }
    
    public ICollection<Recipe> Recipes { get; set; }
}