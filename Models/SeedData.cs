using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Infrastractue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CmsShoppingcartContext
                (serviceProvider.GetRequiredService<DbContextOptions<CmsShoppingcartContext>>()))
            {
                if (context.pages.Any())
                {
                    return;
                }

                context.pages.AddRange(
                    new Page
                    {
                        Title = "Home",
                        Slug = "home",
                        Content = "home page",
                        Sorting = 0,
                    },
                   
                    new Page
                    {
                        Title = "About Us",
                        Slug = "about/us",
                        Content = "About us page",
                        Sorting = 100
                    },
                    new Page
                    {
                        Title = "Services",
                        Slug = "services",
                        Content = "Services page",
                        Sorting = 100
                    },
                    new Page
                    {
                        Title = "Contact",
                        Slug = "contact",
                        Content = "contact page",
                        Sorting = 100
                    }
                    );
                context.SaveChanges();


            }

        }

    }
}

