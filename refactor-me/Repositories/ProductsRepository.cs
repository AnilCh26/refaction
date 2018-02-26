using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using refactor_me.Models;
using AutoMapper;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net.Http;
using System.Web.Http;

using System.Web.Http.Description;
using System.Net;

namespace refactor_me.Repositories
{
    public class ProductsRepository : IProductsRepository
    {


       
        private refactor_meContext Context;
        public ProductsRepository()
        {
            Context = new refactor_meContext();
        }
        public void Dispose()
        {
            
        }

      
        public IList<ProductDTO> GetAllProducts()
        {
          
            return Context.Products.Select(p => new ProductDTO

            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                DeliveryPrice = p.DeliveryPrice,
                //   ProductOptions = p.ProductOptions.ToList()

            }).ToList();
        }

        public IList<ProductDTO> GetProductByName(string name)
        {

            return Context.Products.Where(p => p.Name.Contains(name)).Select(p=> new ProductDTO

            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                DeliveryPrice = p.DeliveryPrice,
                  // ProductOptions = p.ProductOptions.ToList()

            }).ToList();
        }

        public ProductDTO GetProductByGUID(Guid productid)
        {
            if (ProductExists(productid))
            {
                   return Context.Products.Where(p => p.Id.Equals(productid))
                               .Select(p => new ProductDTO
                               {
                                   Id = p.Id,
                                   Name = p.Name,
                                   Description = p.Description,
                                   Price = p.Price,
                                   DeliveryPrice = p.DeliveryPrice,
                   

                }).First();
            }
            else
            { return null; }

               
        
        }

        public void UpdateProduct(Guid productid, Product product)
        {
            if (!ProductExists(productid))
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No Product Found with Id= {0}", productid)),
                    ReasonPhrase = "No Products Found"
                };
                throw new HttpResponseException(response);
            }
            else
            {
                Product res = Context.Products.Single(p => p.Id.Equals(productid));
                res.Name = product.Name;
                res.Description = product.Description;
                res.Price = product.Price;
                res.DeliveryPrice = product.DeliveryPrice;
                res.ModifiedDate = DateTime.Now;
                try
                {
                    Context.SaveChanges();
                   
                }
                catch (Exception ex)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NotAcceptable)
                    {
                        Content = new StringContent("Product Details not updated"),
                        ReasonPhrase = "Product Details not updated"
                    };
                    throw new HttpResponseException(response);
                }
              

            }
           
        }

        public bool ProductExists(Guid id)
        {
            return Context.Products.Count(e => e.Id == id) > 0;
        }

        public void AddNewProduct(Product product)
        {
            product.CreatedDate = DateTime.Now;
            product.ModifiedDate = DateTime.Now;
            Context.Products.Add(product);

            try
            {
                Context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotAcceptable)
                {
                    Content = new StringContent("Product Details not created"),
                    ReasonPhrase = "Product Details not created"
                };
                throw new HttpResponseException(response);
            }
        }

        public void DeleteProduct(Guid productid)
        {
            Product product = Context.Products.Find(productid);
            if (product == null)
            {
             //   return "No Product Exist";
            }
           
            Context.Products.Remove(product);
            Context.SaveChanges();
        }
    }
}