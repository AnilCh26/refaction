using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using System.Text;
using System.Threading.Tasks;
using refactor_me.Controllers;
using refactor_me.Models;
using System.Net.Http;
using System.Web.Http;
using refactor_me.Services;
using Moq;
using NUnit.Framework;

namespace refactor_me.Tests
{
    [TestFixture]
  public  class ProductsControllerTests
    {

        private ProductsController productController;
           [SetUp]
        public void Setup()
        {
            productController = new ProductsController();
        }
        [Test]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
           var result = productController.GetProducts() as List<ProductDTO>;
            Assert.IsTrue(result.Count > 0);
        }
        [Test]
        public void GetproductsByGuid_ShouldReturnMatchingProduct()
        {
            Guid productId =new Guid("c0b2e9cd-b131-40ac-9dd0-9670e0dec8c2");
            var result = productController.GetProduct(productId) as ProductDTO;
            Assert.That(productId.Equals(result.Id));
        }

        
        private Guid GetproductsByGuid(Guid productId)
        {
           ProductDTO productDto=new ProductDTO();
            productDto = productController.GetProduct(productId) as ProductDTO;
            return productDto.Id;
        }
        [Test]
        public void CreateNewProduct_ShouldAddNewProducts()
        {
            var products = GetTestProducts();
            Guid productId = new Guid("c0b2e9cd-b131-40ac-9dd0-9670e0dec8c2");
            // var result = 
            foreach (var product in products)
            {
                productId = product.Id;

                productController.PostProduct(product) ;
            }
            Assert.That(productId.Equals(GetproductsByGuid(productId)));
        }

        [Test]
        public void UpdateProduct_ShouldUpdateDescription()
        {
            Product product = new Product();
            Guid productId = new Guid("c0b2e9cd-b131-40ac-9dd0-9670e0dec8c2");
            product.Id = productId;
            product.Name = "Sony elx";
            product.Price = 200;
            product.DeliveryPrice = 14;
            product.Description = "Sony Mobile Updated";
            productController.PutProduct(productId, product);
            Assert.That(product.Description.Equals(GetproductDescriptionByGuid(productId)));
        }

        private string GetproductDescriptionByGuid(Guid productId)
        {
            ProductDTO productDto = new ProductDTO();
            productDto = productController.GetProduct(productId) as ProductDTO;
            return productDto.Description;
        }
        private List<Product> GetTestProducts()
        {
            var products = new List<Product>();
            products.Add(new Product { Id = Guid.NewGuid(), Name = "LG", Description = "LG Mobile", Price = 150, DeliveryPrice = 190, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            //products.Add(new Product { Id = Guid.NewGuid(), Name = "Sony", Description = "Sony Mobile", Price = 150, DeliveryPrice = 190, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            //products.Add(new Product { Id = Guid.NewGuid(), Name = "Samsung Galaxy S7", Description = "Newest mobile product from Samsung.", Price = Convert.ToDecimal(1024.99), DeliveryPrice =Convert.ToDecimal( 16.99), CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            //products.Add(new Product { Id = Guid.NewGuid(), Name = "Apple iPhone 6S", Description = "Newest mobile product from Apple.", Price = Convert.ToDecimal(2000.30), DeliveryPrice = Convert.ToDecimal(20.50), CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            return products;
        }
         
    }
}
