using CourseStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CourseStore.Controllers
{
    [Route("/api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet("GetAllProducts")]
        public async Task<List<Product>> GetAllProducts()
        {
            return new List<Product>
            {
                new Product(1, "Mouse", 90.00m),
                new Product(2, "Pencil", 5.00m),
                new Product(3, "pen", 25.50m),
            };
        }
    }
}
