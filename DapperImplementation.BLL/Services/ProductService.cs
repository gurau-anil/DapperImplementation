using DapperImplementation.BLL.Services.Interfaces;
using DapperImplementation.DAL.Repository.Interfaces;
using DapperImplementation.Domain.Entities;

namespace DapperImplementation.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<Product> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Get(int id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public Task<Product> Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
