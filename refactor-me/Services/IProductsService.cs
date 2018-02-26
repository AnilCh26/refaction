using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using refactor_me.Models;
namespace refactor_me.Services
{
  public  interface IProductsService
    {
        IList<ProductDTO> GetAllProducts();
        IList<ProductDTO> GetProductByName(string name);
        ProductDTO GetProductByGUID(Guid id);

        void UpdateProduct(Guid id, Product product);
        

        void AddNewProduct(Product product);

        void DeleteProduct(Guid id);
    }
}
