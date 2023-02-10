using MediatR;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Command
{
    public record AddProductCommandcs(Product product):IRequest<Response<object>>;
}
