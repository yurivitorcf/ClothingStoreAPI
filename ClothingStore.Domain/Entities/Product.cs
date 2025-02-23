namespace ClothingStore.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; } //primary key
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty; //change for an enum later
        public int StockQty { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
