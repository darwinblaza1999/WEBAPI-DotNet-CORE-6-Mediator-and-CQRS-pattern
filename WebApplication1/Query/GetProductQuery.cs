using MediatR;
using System.Collections;
using WebApplication1.Models;

namespace WebApplication1.Query
{
    public record GetProductQuery : IRequest<IEnumerable<Product>>;

}
