using WebApplication1.Command;
using WebApplication1.Models;

namespace WebApplication1.Handler
{
    public interface IAddProductHandler
    {
        Task<Product> Handle(AddProductCommandcs request, CancellationToken cancellationToken);
    }
}