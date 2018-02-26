using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using refactor_me.Models;
namespace refactor_me.Services
{
  public  interface IProductOptionsService
    {
        IList<ProductOptionDTO> GetProductOptions(Guid productId);
        ProductOptionDTO GetProductOptions(Guid productId, Guid productOptionId);
        void CreateOption(Guid productId, ProductOption productOption);
        void UpdateOption(Guid productId, ProductOption productOption);
        void DeleteOption(Guid productId, Guid productOptionsId);
       
    }
}
