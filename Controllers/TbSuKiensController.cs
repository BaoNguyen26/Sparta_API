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
    public class TbSuKiensController : Controller
    {
        private readonly DB_Context _context;

        public TbSuKiensController(DB_Context context)
        {
            _context = context;
        }

        // GET: TbSuKiens
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbSuKien.ToListAsync());
        }

        // GET: TbSuKiens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSuKien = await _context.TbSuKien
                .FirstOrDefaultAsync(m => m.SukienId == id);
            if (tbSuKien == null)
            {
                return NotFound();
            }

            return View(tbSuKien);
        }

        // GET: TbSuKiens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbSuKiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SukienId,SukienNgaygio,SukienDiachi,SukienMota")] TbSuKien tbSuKien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbSuKien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbSuKien);
        }

        // GET: TbSuKiens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSuKien = await _context.TbSuKien.FindAsync(id);
            if (tbSuKien == null)
            {
                return NotFound();
            }
            return View(tbSuKien);
        }

        // POST: TbSuKiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SukienId,SukienNgaygio,SukienDiachi,SukienMota")] TbSuKien tbSuKien)
        {
            if (id != tbSuKien.SukienId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbSuKien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbSuKienExists(tbSuKien.SukienId))
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
            return View(tbSuKien);
        }

        // GET: TbSuKiens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSuKien = await _context.TbSuKien
                .FirstOrDefaultAsync(m => m.SukienId == id);
            if (tbSuKien == null)
            {
                return NotFound();
            }

            return View(tbSuKien);
        }

        // POST: TbSuKiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbSuKien = await _context.TbSuKien.FindAsync(id);
            _context.TbSuKien.Remove(tbSuKien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbSuKienExists(int id)
        {
            return _context.TbSuKien.Any(e => e.SukienId == id);
        }
    }
}
