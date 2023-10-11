
namespace server.Models;

public class House
{
    public int Id { get; set; }
    public int? Sqft { get; set; }
    public int? Bedrooms { get; set; }
    public int? Bathrooms { get; set; }
    public int? Price { get; set; }
    public string Description { get; set; }

    public string CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
    public string ImgUrl { get; set; }
    // NOTE once we have our DB created we wont use constructors.
}


