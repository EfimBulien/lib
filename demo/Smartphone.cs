namespace demo;

[Serializable]
public class Smartphone
{
    public required string Brand { get; set; }
    public required string Model { get; set; }
    public int Ram { get; set; }
    public int Rom { get; set; }
    public required string Color { get; set; }
    public double Price { get; set; }
    public int Year { get; set; }
    public double Rating { get; set; }
}