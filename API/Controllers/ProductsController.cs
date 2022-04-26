using Infrastructure.Data;
using core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

//V1.1
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context) //V1.9 constructor
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Product>>> GetProducts() //V1.11
        {
            var products =await _context.Products.ToListAsync();//V1.10

            return Ok(products);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id){
            return await _context.Products.FindAsync(id);//V1.11
        }
    }
}