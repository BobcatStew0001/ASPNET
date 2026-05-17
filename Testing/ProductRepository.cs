using System.Collections.Generic;
using System.Data;
using Dapper;
using Testing.Models;

namespace Testing;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _conn;
    
    public ProductRepository(IDbConnection conn)
    {
        _conn = conn;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _conn.Query<Product>("SELECT * FROM Products");    
    }
    public Product GetProduct(int id)
    {
        return _conn.QueryFirstOrDefault<Product>("SELECT * FROM Products WHERE ProductID = @id", new {id = id});
    }
}