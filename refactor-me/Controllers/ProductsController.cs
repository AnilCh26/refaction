using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using refactor_me.Models;
using refactor_me.Services;

namespace refactor_me.Controllers
{
    public class ProductsController : ApiController
    {

        private IProductsService _productService;
        public ProductsController()
        {
            _productService = new ProductsService();
        }

        [Route("products")]
        [HttpGet]
        public IList<ProductDTO> GetProducts()
        {
            IList < ProductDTO > productDTO= _productService.GetAllProducts();
            if (productDTO.Count == 0 || productDTO == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("No Products Found"),
                    ReasonPhrase = "No Products Found"
                };
                throw new HttpResponseException(response);
            }
            return productDTO;
        }

       [Route("products")]
        [HttpGet]
        
        public IList<ProductDTO> GetProductsByName(String name)
        {
            IList<ProductDTO> productDTO = _productService.GetProductByName(name);

            if (productDTO.Count == 0 || productDTO == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent( string.Format("No Products Found with Name= {0}",name)),
                    ReasonPhrase = "No Products Found"
                };
                throw new HttpResponseException(response);
            }
            return productDTO;

        }
        [Route ("products/{id}")]
        [HttpGet]
        public ProductDTO GetProduct(Guid id)
        {

           ProductDTO productDTO = _productService.GetProductByGUID(id);


            if ( productDTO == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No Products Found with Id= {0}", id)),
                    ReasonPhrase = "No Products Found"
                };
                throw new HttpResponseException(response);
            }
            return productDTO;
        }

        // PUT: api/Products/5     
        [Route("products/{id}")]
        [HttpPut]
        public void PutProduct(Guid id, Product product)
        {
           
            _productService.UpdateProduct(id, product);
             
        }

        // POST: api/Products
        [Route("products")]
        [HttpPost]
        public void PostProduct(Product product)
        {
             _productService.AddNewProduct(product);
            
        }

        // DELETE: api/Products/5
        [Route("{id}")]
        [HttpDelete]
        public void DeleteProduct(Guid productId)
        {
            _productService.DeleteProduct(productId);

           
        }

       
    }
  
}