using ECommerce_MVC_FrameWork.Models;
using ECommerce_MVC_FrameWork.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ECommerce_MVC_FrameWork.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _productRepository.GetProducts();
        }

        public async Task<Product> GetProduct(int id)
        {
           if(id == null)
            {
                throw new ArgumentNullException("Id is not found"); 
            }
            return await _productRepository.GetProduct(id);
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty");
            }

            var products = await _productRepository.GetProductsByName(name);
            if (products == null || !products.Any())
            {
                throw new KeyNotFoundException("Name not found");
            }

            return products;
        }


        public async Task AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }
            if (string.IsNullOrEmpty(product.Name))
            {
                throw new ArgumentException("Product name cannot be null or empty", nameof(product.Name));
            }
            if (product.Price <= 0)
            {
                throw new ArgumentException("Product price must be greater than zero", nameof(product.Price));
            }
            await _productRepository.AddProduct(product);
        }

        public async Task UpdateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }

            var existingProduct = await _productRepository.GetProduct(product.ProductId);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            existingProduct.Name = string.IsNullOrEmpty(product.Name) ? existingProduct.Name : product.Name;
            existingProduct.Description = string.IsNullOrEmpty(product.Description) ? existingProduct.Description : product.Description;
            existingProduct.Price = product.Price <= 0 ? existingProduct.Price : product.Price;
            existingProduct.ImageUrl = string.IsNullOrEmpty(product.ImageUrl) ? existingProduct.ImageUrl : product.ImageUrl;

            await _productRepository.UpdateProduct(existingProduct);
        }

        public async Task DeleteProduct(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid product ID", nameof(id));
            }

            var existingProduct = await _productRepository.GetProduct(id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            await _productRepository.DeleteProduct(id);
        }


    }
}