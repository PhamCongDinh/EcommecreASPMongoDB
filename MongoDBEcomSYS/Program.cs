using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Repositories.order;
using MongoDBEcomSYS.Repositories.product;
using MongoDBEcomSYS.Repositories.shopping;
using MongoDBEcomSYS.Repositories.user;
using MongoDBEcomSYS.Services.order;
using MongoDBEcomSYS.Services.product;
using MongoDBEcomSYS.Services.ShopCart;
using MongoDBEcomSYS.Services.users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MongoEcomsysContext>();

//product
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<CategoryService>();

builder.Services.AddScoped<IDicountRepository, DicountRepository>();
builder.Services.AddScoped<DiscountService>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<InventoryService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();
//user
builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<RolesService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserAddressRepository, UserAddressRepository>();
builder.Services.AddScoped<UserAddressService>();

//shopping cart
builder.Services.AddScoped<IShopCartRepository, ShopCartRepository>();
builder.Services.AddScoped<ICartItemRepository,CartItemRepository>();
builder.Services.AddScoped<ShopCartService>();

//order
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<OrderService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
