using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    internal class ProductRepo : IProductRepo

    {
        private readonly IDbConnection _connection;

        public ProductRepo(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreateProduct(string name, double price, int categoryId, bool onSale, int stockLevel)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID, OnSale, StockLevel) VALUES(@name, @price, @categoryid, @onsale, @stocklevel)", new { name, price, categoryId, onSale, stockLevel });
        }

        public void DeleteProduct(int productId)
        {
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productId", new { productId });
            _connection.Execute("DELETE FROM sales WHERE ProductID = @productId", new { productId });
            _connection.Execute("DELETE FROM products WHERE ProductID = @productId", new { productId });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }

        public void UpdateProductName(int productId, string newName)
        {
            _connection.Execute("UPDATE products SET Name = @newName WHERE ProductID = @productId", new { newName, productId });
        }
    }
}
