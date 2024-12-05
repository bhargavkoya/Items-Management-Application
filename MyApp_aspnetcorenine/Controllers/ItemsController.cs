using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyApp_aspnetcorenine.Data;
using MyApp_aspnetcorenine.Models;

namespace MyApp_aspnetcorenine.Controllers
{
    public class ItemsController : Controller
    {
        private readonly MyAppDataContext _context;

        public ItemsController(MyAppDataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _context.Items
                .Include(x => x.SerialNumber)
                .Include(x => x.Category)
                .Include(x=>x.ItemClients)
                .ThenInclude(y=> y.Client)
                .ToListAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name, Price, CategoryId")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            var item= await _context.Items.FirstOrDefaultAsync(x=> x.Id== id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
                
            }

            return RedirectToAction("Index");
        }
    }
}
