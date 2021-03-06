﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace refactor_me.Models
{
   
   public class Product
    {
        
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [JsonIgnore]
        public bool IsNew { get; }

        public Product()
        {
            Id = Guid.NewGuid();
            IsNew = true;
        }
        public ICollection<ProductOption> ProductOptions { get; set; }
        //public Product(Guid id)
        //{
        //    IsNew = true;
        //    var conn = Helpers.NewConnection();
        //    var cmd = new SqlCommand($"select * from product where id = '{id}'", conn);
        //    conn.Open();

        //    var rdr = cmd.ExecuteReader();
        //    if (!rdr.Read())
        //        return;

        //    IsNew = false;
        //    Id = Guid.Parse(rdr["Id"].ToString());
        //    Name = rdr["Name"].ToString();
        //    Description = (DBNull.Value == rdr["Description"]) ? null : rdr["Description"].ToString();
        //    Price = decimal.Parse(rdr["Price"].ToString());
        //    DeliveryPrice = decimal.Parse(rdr["DeliveryPrice"].ToString());
        //}

        //public void Save()
        //{
        //    var conn = Helpers.NewConnection();
        //    var cmd = IsNew ?
        //        new SqlCommand($"insert into product (id, name, description, price, deliveryprice) values ('{Id}', '{Name}', '{Description}', {Price}, {DeliveryPrice})", conn) :
        //        new SqlCommand($"update product set name = '{Name}', description = '{Description}', price = {Price}, deliveryprice = {DeliveryPrice} where id = '{Id}'", conn);

        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //}

        //public void Delete()
        //{
        //    foreach (var option in new ProductOptions(Id).Items)
        //        option.Delete();

        //    var conn = Helpers.NewConnection();
        //    conn.Open();
        //    var cmd = new SqlCommand($"delete from product where id = '{Id}'", conn);
        //    cmd.ExecuteNonQuery();
        //}
    }
}