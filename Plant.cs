public class Plant
{
    public string Species { get; set; }
    public string PlantType { get; set; }
    public int LightNeeds { get; set; }
    public decimal AskingPrice { get; set; }
    public string City { get; set; }
    public int ZIP { get; set; }
    public bool Sold { get; set; }
    public DateOnly AvailableUntil { get; set; }
}