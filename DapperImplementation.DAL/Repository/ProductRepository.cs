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

        //Mapping single row to multiple objects
        //Dapper split's the returned row by making an assumption that Id columns are named Id or id.
        //If the primary key is different or want split the row at a point other than Id, use the optional splitOn parameter.
        public async Task<IEnumerable<Product>> GetAll()
        {
            using var conn = _connectionFactory.GetConnection;
           var query = @"SELECT * FROM SalesLT.Product p
                        inner join SalesLT.ProductCategory pc on pc.ProductCategoryID = p.ProductCategoryID
                        inner join SalesLT.ProductModel pm on p.ProductModelID = pm.ProductModelID";
            var data = await conn.QueryAsync<Product, ProductCategory, ProductModel, Product>(query, (product, category, model) => {
                product.ProductCategory = category;
                product.ProductModel = model;
                return product;
            }, splitOn: "ProductCategoryID,ProductModelID", commandType: CommandType.Text);
            return data.AsEnumerable();
        }

        //public async Task<Product> GetById(int id)
        //{
        //    using var conn = _connectionFactory.GetConnection;
        //    var query = "SELECT * FROM SalesLT.Product WHERE ProductID = @id";
        //    var param = new DynamicParameters();
        //    param.Add("@id", id);
        //    var data = await conn.QueryFirstOrDefaultAsync<Product>(query, param,
        //        commandType: CommandType.Text);
        //    return data;
        //}

        // Multiple Result
        // Dapper allows to process multiple result grids in a single query.
        public async Task<Product> GetById(int id)
        {
            using var conn = _connectionFactory.GetConnection;
            var query = @"SELECT * FROM SalesLT.Product WHERE ProductID = @id
                            SELECT * FROM SalesLT.SalesOrderDetail WHERE ProductID = @id";
            var param = new DynamicParameters();
            param.Add("@id", id);
            using (var multi = await conn.QueryMultipleAsync(query, param))
            {
                var product = multi.Read<Product>().FirstOrDefault();
                var orders = multi.Read<SalesOrderDetail>().ToList();
                return product;
            }
        }

        // Executing stored procedure
        public async Task<IEnumerable<Product>> GetByIdUsingStoredProcedure(int id)
        {
            using var conn = _connectionFactory.GetConnection;
            var query = @"usp_GetDataFromSp";
            var param = new DynamicParameters();
            param.Add("@id", id);
            var data = await conn.QueryAsync<Product>(query, param,
                commandType: CommandType.StoredProcedure);
            return data;
        }
    }
}
