using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Data;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class DaiLyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DaiLyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DaiLy
        public async Task<IActionResult> Index()
        {
            var list = await _context.DaiLys
                .Include(d => d.HeThongPhanPhoi)
                .ToListAsync();
            return View(list);
        }

        // GET: DaiLy/Create
        public IActionResult Create()
        {
            ViewBag.HeThongPhanPhois = _context.HeThongPhanPhois.ToList();
            return View();
        }

        // POST: DaiLy/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DaiLy daiLy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(daiLy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.HeThongPhanPhois = _context.HeThongPhanPhois.ToList();
            return View(daiLy);
        }

        // GET: DaiLy/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();
            var daiLy = await _context.DaiLys.FindAsync(id);
            if (daiLy == null) return NotFound();
            ViewBag.HeThongPhanPhois = _context.HeThongPhanPhois.ToList();
            return View(daiLy);
        }

        // POST: DaiLy/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, DaiLy daiLy)
        {
            if (id != daiLy.MaDaiLy) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(daiLy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.HeThongPhanPhois = _context.HeThongPhanPhois.ToList();
            return View(daiLy);
        }

        // GET: DaiLy/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var daiLy = await _context.DaiLys
                .Include(d => d.HeThongPhanPhoi)
                .FirstOrDefaultAsync(m => m.MaDaiLy == id);
            if (daiLy == null) return NotFound();
            return View(daiLy);
        }

        // POST: DaiLy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var daiLy = await _context.DaiLys.FindAsync(id);
            _context.DaiLys.Remove(daiLy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
