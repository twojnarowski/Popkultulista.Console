using static PopkultulistaV1.Helpers;

namespace PopkultulistaV1.Models;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }

    public decimal FomoScore { get; set; }

    public ItemType ItemType { get; set; }
}