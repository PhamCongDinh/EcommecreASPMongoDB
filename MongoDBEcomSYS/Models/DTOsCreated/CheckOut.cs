namespace MongoDBEcomSYS.Models.DTOsCreated
{
    public class CheckOut
    {
        public string? UserId { get; set; }
        public decimal? Total { get; set; }
        public string? Address { get; set; }

        public string? Telephone { get; set; }
        public string? Provider { get; set; }
        public string? Receiver { get; set; }
        public string? Status { get; set; }
        public List<OrderItem>? cartItem { get; set; }
    }
}
