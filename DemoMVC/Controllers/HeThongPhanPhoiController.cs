using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Data;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class HeThongPhanPhoiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HeThongPhanPhoiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HeThongPhanPhoi
        public async Task<IActionResult> Index()
        {
            return View(await _context.HeThongPhanPhois.ToListAsync());
        }

        // GET: HeThongPhanPhoi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HeThongPhanPhoi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HeThongPhanPhoi htpp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(htpp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(htpp);
        }

        // GET: HeThongPhanPhoi/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();
            var htpp = await _context.HeThongPhanPhois.FindAsync(id);
            if (htpp == null) return NotFound();
            return View(htpp);
        }

        // POST: HeThongPhanPhoi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, HeThongPhanPhoi htpp)
        {
            if (id != htpp.MaHTPP) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(htpp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(htpp);
        }

        // GET: HeThongPhanPhoi/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();
            var htpp = await _context.HeThongPhanPhois
                .FirstOrDefaultAsync(m => m.MaHTPP == id);
            if (htpp == null) return NotFound();
            return View(htpp);
        }

        // POST: HeThongPhanPhoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var htpp = await _context.HeThongPhanPhois.FindAsync(id);
            _context.HeThongPhanPhois.Remove(htpp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: HeThongPhanPhoi/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();
            var htpp = await _context.HeThongPhanPhois
                .Include(h => h.DaiLys)
                .FirstOrDefaultAsync(m => m.MaHTPP == id);
            if (htpp == null) return NotFound();
            return View(htpp);
        }
    }
}