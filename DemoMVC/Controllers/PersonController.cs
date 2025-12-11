using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Models;
using DemoMVC.Data;
using DemoMVC.Models.Process;

namespace DemoMVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess = new ExcelProcess();
        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.Persons.ToListAsync();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,FullName,Address")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (_context.Persons == null)
            {
                return NotFound();
            }
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonId,FullName,Address")] Person person)
        {
            if (id != person.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Persons == null)
            {
                return NotFound();
            }
            var person = await _context.Persons.FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Persons == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Person' is null.");
            }
            var person = await _context.Persons.FindAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return (_context.Persons?.Any(e => e.PersonId == id)).GetValueOrDefault();
        }
public async Task<IActionResult> Upload()
{
    return View();
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Upload(IFormFile file)
{
    if (file != null)
    {
        string fileExtension = Path.GetExtension(file.FileName);
        if (fileExtension != ".xls" && fileExtension != ".xlsx")
        {
            ModelState.AddModelError("", "Please upload an Excel file.");
            return View();
        }
        else
        {
            var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileExtension;
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Excels");
            Directory.CreateDirectory(folderPath); // đảm bảo thư mục tồn tại

            var filePath = Path.Combine(folderPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var dt = _excelProcess.ExcelToDataTable(filePath);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var ps = new Person();
                    ps.PersonId = dt.Rows[i][0].ToString();
                    ps.FullName = dt.Rows[i][1].ToString();
                    ps.Address = dt.Rows[i][2].ToString();
                _context.Add(ps);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }

    return View();
}
    }
}