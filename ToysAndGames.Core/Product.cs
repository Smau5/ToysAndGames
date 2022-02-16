namespace ToysAndGames.Core;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int? AgeRestriction { get; set; }
    public string Company { get; set; } = string.Empty;
    public decimal Price { get; set; }

}