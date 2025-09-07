using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourRecipes.Api.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(50)]
    public string Email { get; set; }
    [MaxLength(200)]
    public string Password { get; set; }
    
    public ICollection<Category> Categories { get; set; }
}