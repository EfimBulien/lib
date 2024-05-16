namespace ClassLibrarySerialization
{
    [Serializable]
    public class Smartphone
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }

        public Smartphone(string brand, string model, double price, int year)
        {
            Brand = brand;
            Model = model;
            Price = price;
            Year = year;
        }
    }
}
