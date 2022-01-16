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
        //Get/Admin/Pages/Create/5
        public IActionResult Create() => View();
        //Post/Admin/Pages/Details/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Title.ToLower().Replace(" ","-");
                page.Sorting = 100;

                var slug = await context.pages.FirstOrDefaultAsync(x=>x.Slug==page.Slug);
                if (slug !=null)
                {
                    ModelState.AddModelError ("", "The Page already exixt");
                    return View(page);

                }
                context.Add(page);
                await context.SaveChangesAsync();
                TempData["Sucess"] = "The page has been added!";

                return RedirectToAction("Index");
            }

            return View(page);
        }
        //Get/Admin/Pages/Edits/5
        public async Task<IActionResult> Edit(int id)
        {
            Page page = await context.pages.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }
        //Post/Admin/Pages/Details/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug=page.Id==1 ?"home" : page.Slug = page.Title.ToLower().Replace(" ", "-");

               

                var slug = await context.pages.Where(x=>x.Id!=page.Id).FirstOrDefaultAsync(x => x.Slug == page.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The Title already exixt");
                    return View(page);

                }
                context.Update(page);
                await context.SaveChangesAsync();
                TempData["Sucess"] = "The page has been Edited!";

                return RedirectToAction("Edit",new{id =page.Id});
            }

            return View(page);
        }
        //Get/Admin/Pages/Details/5
        public async Task<IActionResult> Delete(int id)
        {
            Page page = await context.pages.FindAsync(id);
            if (page == null)
            {
                TempData["Error"] = "The page Does Not Exist!";
            }
            else
            {
                context.pages.Remove(page);
                await context.SaveChangesAsync();

                TempData["Sucess"] = "The page has been sucessfully removed";
            }

            return RedirectToAction("Index");
        }
    }
}
