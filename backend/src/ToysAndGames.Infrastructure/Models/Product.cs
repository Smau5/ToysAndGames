namespace ToysAndGames.Data.Models;

public class Product
{
    
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string?  Company { get; set; }
    public int? AgeRestriction { get; set; }
    public decimal Price { get; set; }
    
    public Byte[]? Image { get; set; }

    //Navigation Properties
    //public Companies Company { get; set; }

}