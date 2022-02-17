using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ToysAndGames.Api.Models;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int? AgeRestriction { get; set; }
    public string Company { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Byte[]? Image { get; set; }
}

public class ProductRequestDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(100)]
    public string? Description { get; set; }
    [Range(0,100)]
    public int? AgeRestriction { get; set; }
    [Required]
    [MaxLength(50)]
    public string Company { get; set; } = string.Empty;
    [Required]
    [Range(1,1000)]
    public decimal Price { get; set; }
    public Byte[]? Image { get; set; } 
}
