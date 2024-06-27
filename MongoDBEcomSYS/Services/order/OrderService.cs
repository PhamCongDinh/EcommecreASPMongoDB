using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Models.DTOsCreated;
using MongoDBEcomSYS.Repositories.order;

namespace MongoDBEcomSYS.Services.order
{
    public class OrderService
    {
        private readonly IOrderRepository _odR;
        public OrderService(IOrderRepository odR) { _odR = odR; }
        public async Task<List<OrderDetails>> getorderdetal(string uId)
        {
            return await _odR.GetAllOrders(uId);
        }
        public async Task<List<OrderItem>> getorderItem(string Oid)
        {
            return await _odR.GetOrderItems(Oid);
        }
        public async Task<OrderDetails> Add(CheckOut checkOut)
        {
            return await _odR.AddOrder(checkOut);
        }
    }
}
