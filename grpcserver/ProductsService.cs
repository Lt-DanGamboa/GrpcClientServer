using System.Collections.Generic;
using System.Threading.Tasks;
using curso;
using Grpc.Core;
using System.Linq;

namespace grpcserver{
    public class ProductsService : curso.ProductsService.ProductsServiceBase
    {

        private readonly List<Product> products = new List<Product>();

        public ProductsService()
        {
            products.Add(new Product(){Id = 1, Name = "Chocolate", Price = 10.50, IsAvaible = true, Category = curso.Category.Food});
            products.Add(new Product(){Id = 2, Name = "Mouse", Price = 150.50, IsAvaible = false, Category = curso.Category.Technology});
        }
        public override Task<Product> GetProductById(ProductRequest request, ServerCallContext context)
        {
            Product product = products.FirstOrDefault(products=>products.Id == request.Id);
            return Task.FromResult(product);
        }    
    }
}
