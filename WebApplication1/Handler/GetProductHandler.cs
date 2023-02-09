using MediatR;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.Query;

namespace WebApplication1.Handler
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, IEnumerable<Product>>
    {
        private readonly FakeDatasource _datasource;
        public GetProductHandler(FakeDatasource datasource) => _datasource = datasource;


        public async Task<IEnumerable<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
            => await _datasource.GetAllProducts();
    }
}
