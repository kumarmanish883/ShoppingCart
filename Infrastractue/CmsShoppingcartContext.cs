using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Infrastractue
{
    public class CmsShoppingcartContext:DbContext
    {
        public CmsShoppingcartContext(DbContextOptions<CmsShoppingcartContext>options)
            :base(options)
         {

        }
        public DbSet<Page> pages { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
