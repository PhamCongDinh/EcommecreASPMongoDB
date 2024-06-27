using MongoDB.Driver;

namespace MongoDBEcomSYS.Models
{
    public class MongoEcomsysContext
    {
        private readonly IConfiguration _configuration;
        private IMongoDatabase _MGdb;

        public MongoEcomsysContext(IConfiguration configuration) {
            _configuration = configuration;
            var connectionString = _configuration["MongoDBSettings:Dbconnection"];
            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            _MGdb = mongoClient.GetDatabase(mongoUrl.DatabaseName);    
        }
        public IMongoCollection<Product> Products => _MGdb.GetCollection<Product>("product");
        public IMongoCollection<ProductCategory> ProductCategories =>_MGdb.GetCollection<ProductCategory>("product_category");
        public IMongoCollection<ProductInventory> ProductInventories => _MGdb.GetCollection<ProductInventory>("product_inventory");
        public IMongoCollection<Dicounts> Dicounts => _MGdb.GetCollection<Dicounts>("dicount");

        public IMongoCollection<User> Users => _MGdb.GetCollection<User>("user");
        public IMongoCollection<UserAddress> UserAddresses => _MGdb.GetCollection<UserAddress>("userAddress");
        public IMongoCollection<Roles> Roles => _MGdb.GetCollection<Roles>("role");

        public IMongoCollection<ShoppingSession> ShoppingSessions => _MGdb.GetCollection<ShoppingSession>("shopping_session");
        public IMongoCollection<CartItem> CartItems => _MGdb.GetCollection<CartItem>("cart_item");


        public IMongoCollection<OrderDetails> OrderDetail => _MGdb.GetCollection<OrderDetails>("order_detail");
        public IMongoCollection<OrderItem> OrderItems => _MGdb.GetCollection<OrderItem>("order_item");
        public IMongoCollection<PaymentDetail> PaymentDetails => _MGdb.GetCollection<PaymentDetail>("payment_detail");

    }
}

