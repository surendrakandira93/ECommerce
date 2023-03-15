using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECommerce.Data
{
    public class EcommerceDbContext:DbContext
    {
        public EcommerceDbContext() : base("name=DefaultConnection")
        {
        }
        public virtual DbSet<Category> Categorys { get; set; }

    }
}