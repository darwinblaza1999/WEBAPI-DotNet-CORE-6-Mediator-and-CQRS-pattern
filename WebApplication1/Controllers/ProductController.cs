using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Command;
using WebApplication1.Models;
using WebApplication1.Query;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly ISender _sender;
        public ProductController(ISender sender) => _sender = sender;

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var product = await _sender.Send(new GetProductQuery());
            return Ok(product);
        }
        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<IActionResult> GetProducts(int id)
        {
            var product = await _sender.Send(new GetProductQueryId(id));
            return Ok(product);
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
           var productret =  await _sender.Send(new AddProductCommandcs(product));
            return CreatedAtRoute("GetProductById", new { Id = productret.Id }, productret);
        }


    }
}
