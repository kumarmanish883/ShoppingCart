using Microsoft.EntityFrameworkCore;
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
    }
}
