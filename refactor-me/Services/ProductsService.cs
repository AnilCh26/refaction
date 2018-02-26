using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using refactor_me.Repositories;
using refactor_me.Models;
namespace refactor_me.Services
{
    public class ProductsService: IProductsService
    {
        private IProductsRepository _productRepository;
        public ProductsService(IProductsRepository productsRepository)
        {
            this._productRepository = productsRepository;
        }

        public ProductsService()
        {
            _productRepository = new ProductsRepository();
        }
        public void AddNewProduct(Product product)
        {
            _productRepository.AddNewProduct(product);
        }

        public void DeleteProduct(Guid id)
        {
            _productRepository.DeleteProduct(id);
        }

        public IList<ProductDTO> GetAllProducts()
        {
           return  _productRepository.GetAllProducts();
        }

        public ProductDTO GetProductByGUID(Guid id)
        {
            return _productRepository.GetProductByGUID(id);
        }

        public IList<ProductDTO> GetProductByName(string name)
        {
            return _productRepository.GetProductByName(name);
        }

       

        public void UpdateProduct(Guid id, Product product)
        {
            _productRepository.UpdateProduct(id, product);
        }
    }
}