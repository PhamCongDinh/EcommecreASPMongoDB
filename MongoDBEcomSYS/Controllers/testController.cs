//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using MongoDB.Driver;
//using MongoDBEcomSYS.Models;

//namespace MongoDBEcomSYS.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class testController : ControllerBase
//    {
//        private readonly MongoEcomsysContext _db;
//        public testController(MongoEcomsysContext db) {
//            _db = db;
//        }
//        [HttpGet]
//        public async Task<IActionResult> get()
//        {
//            return Ok(await _db.Products.Find(_ => true).ToListAsync());
//        }
//    }
//}
