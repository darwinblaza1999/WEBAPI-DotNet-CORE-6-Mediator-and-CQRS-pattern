using MediatR;
using WebApplication1.Models;

namespace WebApplication1.Command
{
    public record AddProductCommandcs(Product product):IRequest<Product>;
}
