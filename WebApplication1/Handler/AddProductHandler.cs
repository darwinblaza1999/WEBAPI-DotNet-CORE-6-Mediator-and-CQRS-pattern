using MediatR;
using WebApplication1.Command;
using WebApplication1.Models;

namespace WebApplication1.Handler
{
    public class AddProductHandler : IRequestHandler<AddProductCommandcs, Product>
    {
        private readonly FakeDatasource _datasource;

        public AddProductHandler(FakeDatasource datasource) => _datasource = datasource;
        public async Task<Product> Handle(AddProductCommandcs request, CancellationToken cancellationToken)
        {
            await _datasource.AddProduct(request.product);

            return request.product;
        }
    }
}
