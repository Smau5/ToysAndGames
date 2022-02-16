using System.ComponentModel.DataAnnotations;

namespace ToysAndGames.Api.Models;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int? AgeRestriction { get; set; }
    public string Company { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

public class ProductRequestDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int? AgeRestriction { get; set; }
    [Required]
    public string Company { get; set; } = string.Empty;
    [Required]
    public decimal Price { get; set; }
}
