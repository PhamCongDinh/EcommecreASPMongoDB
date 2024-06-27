using MongoDB.Driver;
using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Models.DTOsCreated;

namespace MongoDBEcomSYS.Repositories.order
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MongoEcomsysContext _db;
        public OrderRepository(MongoEcomsysContext db) { _db= db; }

        public async Task<OrderDetails> AddOrder(CheckOut checkOut)
        {
            var payment = new PaymentDetail
            {
                Amount = (int)checkOut.Total,
                Provider = checkOut.Provider,
                Status = "0",
                CreatedAt = DateTime.Now,

            };
            await _db.PaymentDetails.InsertOneAsync(payment);
            var order = new OrderDetails
            {
                UserId = checkOut.UserId,
                Total = checkOut.Total,
                PaymentId = payment.Id,
                Telephone = checkOut.Telephone,
                Address = checkOut.Address,
                Receiver = checkOut.Receiver,
                CreatedAt = DateTime.Now

            };
            await _db.OrderDetail.InsertOneAsync(order);
            foreach(var Item in checkOut.cartItem)
            {
                var orderitem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = Item.ProductId,
                    Quantity = Item.Quantity
                };
                await _db.OrderItems.InsertOneAsync(orderitem);
                //update lai quatity
            }
            return order;
        }

        public async Task<List<OrderDetails>> GetAllOrders(string uId)
        {
            var lstOrder=  await _db.OrderDetail.Find(x =>x.UserId == uId).ToListAsync();
            return lstOrder;
        }

        public async Task<List<OrderItem>> GetOrderItems(string OId)
        {
            var lstOI = await _db.OrderItems.Find(x =>x.OrderId == OId).ToListAsync();
            return lstOI;
        }
    }
}
