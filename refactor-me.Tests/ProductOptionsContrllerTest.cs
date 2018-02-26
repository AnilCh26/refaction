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
    public  class ProductOptionsContrllerTest
    {
        private ProductOptionsController productOptionsController;
        [SetUp]
        public void Setup()
        {
            productOptionsController = new ProductOptionsController();
        }

        [Test]
        public void GetAllProductoptionsByProductId_ShouldReturnAllProductOptions()
        {
            var result = productOptionsController.GetProductOptions(new Guid("c0b2e9cd-b131-40ac-9dd0-9670e0dec8c2")) as List<ProductOptionDTO>;
            Assert.IsTrue(result.Count > 0);
        }
        [Test]
        public void GetAllProductoptionsByProductIdandOptionId_ShouldReturnAllProductOptions()
        {
            var result = productOptionsController.GetProductOptions(new Guid("c0b2e9cd-b131-40ac-9dd0-9670e0dec8c2"),new Guid("955e77d8-46fc-4d8b-bf7f-0c8abd98e321")) as ProductOptionDTO;
            Assert.That(result.Id.Equals(new Guid("955e77d8-46fc-4d8b-bf7f-0c8abd98e321")));
        }

        [Test]
        public void CreateProductOptions_ShouldCreateProductOptions()
        {
            var products = GetProductOptions();
            Guid productId = new Guid("c0b2e9cd-b131-40ac-9dd0-9670e0dec8c2");
            Guid productOptionId = new Guid("c0b2e9cd-b131-40ac-9dd0-9670e0dec8c2");
            // var result = 
            foreach (var product in products)
            {
                productId = product.ProductId;
                productOptionId= product.Id;
                productOptionsController.PostProductOption(productId, product);
            }
            Assert.That(productOptionId.Equals(GetproductOptionsByGuid(productId, productOptionId)));
        }
        [Test]
        public void UpdateProductOptions_ShouldUpdateProductOptions()
        {
            ProductOption productOption = new ProductOption();
            productOption.Id = new Guid("955e77d8-46fc-4d8b-bf7f-0c8abd98e321");
            productOption.Name = "Sony G5.6";
            productOption.Description = "Sony White +";
            productOption.ProductId = new Guid("c0b2e9cd-b131-40ac-9dd0-9670e0dec8c2");
            productOptionsController.PutProductOption(productOption.ProductId, productOption);
            Assert.That(productOption.Description.Equals(GetproductOptionsDescriptionByGuid(productOption.ProductId, productOption.Id)));

        }
            private IList<ProductOption> GetProductOptions()
        {
            var products = new List<ProductOption>();
            products.Add(new ProductOption { Id = Guid.NewGuid(), Name = "White", Description = "White LG Mobile", ProductId =new Guid( "0888ee34-9619-4ece-88bc-1db12f60c17d"), CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            products.Add(new ProductOption { Id = Guid.NewGuid(), Name = "Black", Description = "Black LG Mobile", ProductId = new Guid("0888ee34-9619-4ece-88bc-1db12f60c17d"), CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            products.Add(new ProductOption { Id = Guid.NewGuid(), Name = "White", Description = "White Samsung Mobile", ProductId = new Guid("bf8a3670-b0c0-439d-ba1b-2bdc0a444cbc"), CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            products.Add(new ProductOption { Id = Guid.NewGuid(), Name = "Black", Description = "Black amsung Mobile", ProductId = new Guid("bf8a3670-b0c0-439d-ba1b-2bdc0a444cbc"), CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
           
            return products;

        }
        private Guid GetproductOptionsByGuid(Guid productId,Guid productOptionId)
        {
            ProductOptionDTO productDto = new ProductOptionDTO();
            productDto = productOptionsController.GetProductOptions(productId,productOptionId) as ProductOptionDTO;
            return productDto.Id;
        }
        private string GetproductOptionsDescriptionByGuid(Guid productId, Guid productOptionId)
        {
            ProductOptionDTO productDto = new ProductOptionDTO();
            productDto = productOptionsController.GetProductOptions(productId, productOptionId) as ProductOptionDTO;
            return productDto.Description;
        }
    }
}
