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
    public class ProductOptionsController : ApiController
    {
        private IProductOptionsService _productOptionService;
        
        public ProductOptionsController()
        {
            _productOptionService = new ProductOptionsService();
        }
        // GET: api/ProductOptions/5
        [Route("product/{productId}/options")]
        [HttpGet]
        public IList<ProductOptionDTO> GetProductOptions(Guid productId)
        {
            IList < ProductOptionDTO > productOptionDTO= _productOptionService.GetProductOptions(productId);
             
            if (productOptionDTO.Count == 0 || productOptionDTO == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No Product Options Found with ProductID={0}",productId)),
                    ReasonPhrase = "No Product Options Found"
                };
                throw new HttpResponseException(response);
            }
            return productOptionDTO;

        }
        [Route("product/{productId}/options/{productOptionId}")]
        [HttpGet]
        public ProductOptionDTO GetProductOptions(Guid productId, Guid productOptionId)
        {
            ProductOptionDTO productOptionDTO= _productOptionService.GetProductOptions(productId, productOptionId);
            if ( productOptionDTO == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No Product Options Found with ProductID={0}", productId)),
                    ReasonPhrase = "No Product Options Found"
                };
                throw new HttpResponseException(response);
            }
            return productOptionDTO;
        }


        // PUT: api/ProductOptions/5
        [Route("product/{productId}/options/{id}")]
        [HttpPut]
        
        public void PutProductOption(Guid productId, ProductOption productOption)
        {
            _productOptionService.UpdateOption(productId, productOption);

            
        }

        
        [Route("product/{productId}/options")]
        [HttpPost]
        
        public void PostProductOption(Guid productId, ProductOption productOption)
        {

            _productOptionService.CreateOption(productId, productOption);
                       
        }

        // DELETE: api/ProductOptions/5
        [Route("product/{productId}/options/{productOptionId}")]
        [HttpPost]
        
        public void DeleteProductOption(Guid productId, Guid productOptionId)
        {
            _productOptionService.DeleteOption(productId, productOptionId);
            
        }


    }
}