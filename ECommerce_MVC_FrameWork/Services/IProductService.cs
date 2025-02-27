using ECommerce_MVC_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_MVC_FrameWork.Services
{
    internal interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> GetProduct(int id);
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
