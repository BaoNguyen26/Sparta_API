using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API.Sparta.Models;

namespace API.Sparta.Controllers
{
    public class TbLienHesController : Controller
    {
        private readonly DB_Context _context;

        public TbLienHesController(DB_Context context)
        {
            _context = context;
        }

        // GET: TbLienHes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbLienHe.ToListAsync());
        }

        // GET: TbLienHes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLienHe = await _context.TbLienHe
                .FirstOrDefaultAsync(m => m.LienheId == id);
            if (tbLienHe == null)
            {
                return NotFound();
            }

            return View(tbLienHe);
        }

        // GET: TbLienHes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbLienHes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LienheId,LienheCoso,LienheTencose,LienheDiachi,LienheDienthoai,LienheEmail,LienheLinkfb,LienheLinktw,LienheLinkin,LienheLinkgmap")] TbLienHe tbLienHe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbLienHe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbLienHe);
        }

        // GET: TbLienHes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLienHe = await _context.TbLienHe.FindAsync(id);
            if (tbLienHe == null)
            {
                return NotFound();
            }
            return View(tbLienHe);
        }

        // POST: TbLienHes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LienheId,LienheCoso,LienheTencose,LienheDiachi,LienheDienthoai,LienheEmail,LienheLinkfb,LienheLinktw,LienheLinkin,LienheLinkgmap")] TbLienHe tbLienHe)
        {
            if (id != tbLienHe.LienheId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbLienHe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbLienHeExists(tbLienHe.LienheId))
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
            return View(tbLienHe);
        }

        // GET: TbLienHes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLienHe = await _context.TbLienHe
                .FirstOrDefaultAsync(m => m.LienheId == id);
            if (tbLienHe == null)
            {
                return NotFound();
            }

            return View(tbLienHe);
        }

        // POST: TbLienHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbLienHe = await _context.TbLienHe.FindAsync(id);
            _context.TbLienHe.Remove(tbLienHe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbLienHeExists(int id)
        {
            return _context.TbLienHe.Any(e => e.LienheId == id);
        }
    }
}
