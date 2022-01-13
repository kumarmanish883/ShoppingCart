using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Infrastractue;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        private readonly CmsShoppingcartContext context;
        public PagesController(CmsShoppingcartContext context)
        {
            this.context = context;
        }
        
        //Get/Admin/Pages
        public async Task<IActionResult> Index()
        {
            IQueryable<Page> pages = from p in context.pages orderby p.Sorting select p;
            List<Page> pagesList = await pages.ToListAsync();

            return View(pagesList);
        }
        //Get/Admin/Pages/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Page page = await context.pages.FirstOrDefaultAsync(x => x.Id == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }
    }
}
