namespace MongoDBEcomSYS.Models.DTOsCreated
{
    public class ProductDTO
    {
        public string Name { get; set; }

        public string Desc { get; set; }

        public string Image { get; set; }

        public string Sku { get; set; }

        public decimal Price { get; set; }
        public string CategoryId { get; set; }
        public int Quantity { get; set; }

        public string? DicountId { get; set; }
    }
}
