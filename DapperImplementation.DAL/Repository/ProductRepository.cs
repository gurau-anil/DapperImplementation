using Dapper;
using DapperImplementation.DAL.Infrastructure;
using DapperImplementation.DAL.Repository.Interfaces;
using DapperImplementation.Domain.Entities;
using System.Data;

namespace DapperImplementation.DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ProductRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            using var conn = _connectionFactory.GetConnection;
            var query = "SELECT * FROM SalesLT.Product";
            var data = await conn.QueryAsync<Product>(query, commandType: CommandType.Text);
            return data.ToList();

        }

        public async Task<Product> GetById(int id)
        {
            using var conn = _connectionFactory.GetConnection;
            var query = "SELECT * FROM SalesLT.Product WHERE ProductID = @id";
            var param = new DynamicParameters();
            param.Add("@id", id);
            var data = await conn.QueryFirstOrDefaultAsync<Product>(query, param,
                commandType: CommandType.Text);
            return data;
        }
    }
}
