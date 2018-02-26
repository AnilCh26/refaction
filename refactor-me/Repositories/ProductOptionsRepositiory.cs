using System.Collections.Generic;
using System.Linq;
using System.Web;
using refactor_me.Models;
using AutoMapper;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net.Http;
using System.Web.Http;
using System;
using System.Net;

namespace refactor_me.Repositories
{
    public class ProductOptionsRepositiory : IProductOptionsRepositiory
    {

        private refactor_meContext Context;

        public ProductOptionsRepositiory()
        {
            Context=  new refactor_meContext();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IList<ProductOptionDTO> GetProductOptions(Guid productId)
        {
            return Context.ProductOptions.Where(p => p.ProductId.Equals(productId)).Select(p => new ProductOptionDTO

            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ProductId = p.ProductId,
                CreatedDate = p.CreatedDate,ModifiedDate=p.ModifiedDate,
           
               }).ToList();
        }

        public ProductOptionDTO GetProductOptions(Guid productId,Guid productOptionId)
        {
            return Context.ProductOptions.Where(p => p.ProductId.Equals(productId) && p.Id.Equals(productOptionId)).Select(p => new ProductOptionDTO

            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ProductId = p.ProductId,
                CreatedDate = p.CreatedDate,
                ModifiedDate = p.ModifiedDate,

            }).First();
        }

        public void CreateOption(Guid productId,ProductOption productOption)
        {
            if (ProductExists(productId))
            {
                productOption.ProductId = productId;
                productOption.CreatedDate = DateTime.Now;
                productOption.ModifiedDate = DateTime.Now;
                Context.ProductOptions.Add(productOption);

                try
                {
                    Context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NotAcceptable)
                    {
                        Content = new StringContent("ProductOptions Details not created"),
                        ReasonPhrase = "ProductOptions Details not created"
                    };
                    throw new HttpResponseException(response);
                }

            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Product ID is not found Id= {0}",productId)),
                    ReasonPhrase = " Product ID is not found"
                };
                throw new HttpResponseException(response);
            }

        }

        public void UpdateOption(Guid productId, ProductOption productOption)
        {
            if (ProductOptionExists(productOption.Id)==true)
            {
                productOption.ModifiedDate = DateTime.Now;
                ProductOption res = Context.ProductOptions.Where(p => p.ProductId.Equals(productId) && p.Id.Equals(productOption.Id)).First();
                res.Name = productOption.Name;
                res.Description = productOption.Description;
                res.ModifiedDate = DateTime.Now;
               
                try
                {
                    Context.SaveChanges();

                }
               
                catch (DbUpdateConcurrencyException)
                {

                    throw new HttpResponseException(System.Net.HttpStatusCode.NotModified);
                    
                }
                }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("ProductOptions ID is not found Id= {0}", productOption.Id)),
                    ReasonPhrase = " ProductOptions ID is not found"
                };
                throw new HttpResponseException(response);

            }
        }

        public void DeleteOption(Guid productId,Guid productOptionsId)
        {
            ProductOption productOption = Context.ProductOptions.Find(productOptionsId);
            if (productOption == null)
            {
               // return NotFound();
            }

            Context.ProductOptions.Remove(productOption);
            Context.SaveChanges();

        }
        public bool ProductOptionExists(Guid id)
        {
            return Context.ProductOptions.Count(e => e.Id == id) > 0;
        }
        public bool ProductExists(Guid id)
        {
            return Context.Products.Count(e => e.Id == id) > 0;
        }

    }
}