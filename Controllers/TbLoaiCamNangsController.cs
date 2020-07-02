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
    public class TbLoaiCamNangsController : Controller
    {
        private readonly DB_Context _context;

        public TbLoaiCamNangsController(DB_Context context)
        {
            _context = context;
        }

        // GET: TbLoaiCamNangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbLoaiCamNang.ToListAsync());
        }

        // GET: TbLoaiCamNangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLoaiCamNang = await _context.TbLoaiCamNang
                .FirstOrDefaultAsync(m => m.LoaicamnangId == id);
            if (tbLoaiCamNang == null)
            {
                return NotFound();
            }

            return View(tbLoaiCamNang);
        }

        // GET: TbLoaiCamNangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbLoaiCamNangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoaicamnangId,LoaicamnangTieude")] TbLoaiCamNang tbLoaiCamNang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbLoaiCamNang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbLoaiCamNang);
        }

        // GET: TbLoaiCamNangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLoaiCamNang = await _context.TbLoaiCamNang.FindAsync(id);
            if (tbLoaiCamNang == null)
            {
                return NotFound();
            }
            return View(tbLoaiCamNang);
        }

        // POST: TbLoaiCamNangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoaicamnangId,LoaicamnangTieude")] TbLoaiCamNang tbLoaiCamNang)
        {
            if (id != tbLoaiCamNang.LoaicamnangId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbLoaiCamNang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbLoaiCamNangExists(tbLoaiCamNang.LoaicamnangId))
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
            return View(tbLoaiCamNang);
        }

        // GET: TbLoaiCamNangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLoaiCamNang = await _context.TbLoaiCamNang
                .FirstOrDefaultAsync(m => m.LoaicamnangId == id);
            if (tbLoaiCamNang == null)
            {
                return NotFound();
            }

            return View(tbLoaiCamNang);
        }

        // POST: TbLoaiCamNangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbLoaiCamNang = await _context.TbLoaiCamNang.FindAsync(id);
            _context.TbLoaiCamNang.Remove(tbLoaiCamNang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbLoaiCamNangExists(int id)
        {
            return _context.TbLoaiCamNang.Any(e => e.LoaicamnangId == id);
        }
    }
}
