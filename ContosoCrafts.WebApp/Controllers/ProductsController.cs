using ContosoCrafts.WebApp.Models;
using ContosoCrafts.WebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductsService productsService)
        {
            ProductsService = productsService;
        }
        public JsonFileProductsService ProductsService { get; }
        
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductsService.GetProducts();
        }

        //[HttpPatch]
        [Route("rate")]
        [HttpGet]
        // api/products/rate?productId=jenlooper-cactus&rating=5
        public ActionResult Get(
            [FromQuery] string productId,
            [FromQuery] int rating)
        {
            ProductsService.AddRating(productId, rating);
            return Ok();
        }

    }
}
