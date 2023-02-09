using MediatR;
using WebApplication1.Models;
using WebApplication1.Query;

namespace WebApplication1.Handler
{
    public class GetProductByHandler : IRequestHandler<GetProductQueryId, Product>
    {
        private readonly FakeDatasource _datasource;
        public GetProductByHandler(FakeDatasource datasource) => _datasource = datasource;
        public async Task<Product> Handle(GetProductQueryId request, CancellationToken cancellationToken)
            => await _datasource.GetProductById(request.id);
    }
}
