namespace MongoDBEcomSYS.Models.DTOsGet
{
    public class CartItemDetail
    {
        public string Id { get; set; }
        public string SessionId { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Decimal SumMoney { get; set; }
    }
}
