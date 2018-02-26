using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace refactor_me.Models
{
    public class refactor_meContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public refactor_meContext() : base("name=refactor_meContext")
        {
        }

        public System.Data.Entity.DbSet<refactor_me.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<refactor_me.Models.ProductOption> ProductOptions { get; set; }
    }
}
