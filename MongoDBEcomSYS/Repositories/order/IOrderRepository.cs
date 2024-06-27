using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Models.DTOsCreated;

namespace MongoDBEcomSYS.Repositories.order
{
    public interface IOrderRepository
    {
        public Task<List<OrderDetails>> GetAllOrders(string uId);
        public Task<List<OrderItem>> GetOrderItems(string OId);
        public Task<OrderDetails> AddOrder(CheckOut checkOut);
    }
}
