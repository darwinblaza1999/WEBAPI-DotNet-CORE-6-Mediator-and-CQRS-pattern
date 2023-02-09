using MediatR;
using WebApplication1.Models;

namespace WebApplication1.Query
{
    public record GetProductQueryId(int id) : IRequest<Product>;
}
