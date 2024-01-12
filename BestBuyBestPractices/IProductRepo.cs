using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    public interface IProductRepo
    {
        public IEnumerable<Product> GetAllProducts();
        public void CreateProduct(string name, double price, int categoryId, bool onSale, int stockLevel);
        public void UpdateProductName(int productId, string newName);
        public void DeleteProduct(int productId);
    }
}
