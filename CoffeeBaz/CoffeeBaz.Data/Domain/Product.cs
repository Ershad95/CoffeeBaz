
namespace CoffeeBaz.Data.Domain;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public bool Vip { get; set; }
    public decimal Price { get; set; }
    public bool Active { get; set; }
    public int CatergoryId { get; set; }
    //----------Navigation Property-----------
    public virtual Category Catergory { get; set; }
}

