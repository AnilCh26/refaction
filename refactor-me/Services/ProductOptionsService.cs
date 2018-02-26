using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using refactor_me.Repositories;
using refactor_me.Models;

namespace refactor_me.Services
{
    public class ProductOptionsService : IProductOptionsService 
    {

        IProductOptionsRepositiory _productOptionsRepository;
        //public ProductOptionsService(IProductOptionsService productOptionsRepository)
        //{
        //    this._productOptionsRepository = productOptionsRepository;
        //}
        public ProductOptionsService()
        {
            _productOptionsRepository = new ProductOptionsRepositiory();
        }
        public void CreateOption(Guid productId, ProductOption productOption)
        {
            _productOptionsRepository.CreateOption(productId, productOption);
        }

        public void DeleteOption(Guid productId, Guid productOptionsId)
        {
            _productOptionsRepository.DeleteOption(productId, productOptionsId);
        }

        public IList<ProductOptionDTO> GetProductOptions(Guid productId)
        {
           return  _productOptionsRepository.GetProductOptions(productId);
        }

        public ProductOptionDTO GetProductOptions(Guid productId, Guid productOptionId)
        {
            return _productOptionsRepository.GetProductOptions(productId, productOptionId);
        }

       

        public void UpdateOption(Guid productId, ProductOption productOption)
        {
            _productOptionsRepository.UpdateOption(productId, productOption);
        }
    }
}