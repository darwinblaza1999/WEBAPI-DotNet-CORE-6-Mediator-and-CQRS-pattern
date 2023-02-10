using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Command;
using WebApplication1.Models;
using WebApplication1.Query;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator) => _mediator = mediator;

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var product = await _mediator.Send(new GetProductQuery());
            return Ok(product);
        }
        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<IActionResult> GetProducts(int id)
        {
            var product = await _mediator.Send(new GetProductQueryId(id));
            return Ok(product);
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
           var productret =  await _mediator.Send(new AddProductCommandcs(product));
            if(productret.Code == 200)
            {
                return Ok(productret);
            }
            else
            {
                return BadRequest(productret);
            }
        }
    }
}
