using System;
using Grpc.Net.Client;
using curso;
using System.Threading.Tasks;

namespace grpcclient
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var productId = args != null && args.Length > 0 && int.TryParse(args[0], out int id)? id : 1;
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ProductsService.ProductsServiceClient(channel);
            var request = new ProductRequest(){Id = productId};
            Product product = await client.GetProductByIdAsync(request);
            Console.WriteLine($"ProductId: {product.Id}, ProductName: {product.Name}, IsAbailable: {product.IsAvaible}, Category: {product.Category}");
        }
    }
}
