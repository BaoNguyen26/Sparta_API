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
    public class TbDoiTacsController : Controller
    {
        private readonly DB_Context _context;

        public TbDoiTacsController(DB_Context context)
        {
            _context = context;
        }

        // GET: TbDoiTacs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbDoiTac.ToListAsync());
        }

        // GET: TbDoiTacs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDoiTac = await _context.TbDoiTac
                .FirstOrDefaultAsync(m => m.DoitacId == id);
            if (tbDoiTac == null)
            {
                return NotFound();
            }

            return View(tbDoiTac);
        }

        // GET: TbDoiTacs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbDoiTacs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoitacId,DoitacTen,DoitacMota,DoitacHinhanh")] TbDoiTac tbDoiTac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDoiTac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbDoiTac);
        }

        // GET: TbDoiTacs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDoiTac = await _context.TbDoiTac.FindAsync(id);
            if (tbDoiTac == null)
            {
                return NotFound();
            }
            return View(tbDoiTac);
        }

        // POST: TbDoiTacs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoitacId,DoitacTen,DoitacMota,DoitacHinhanh")] TbDoiTac tbDoiTac)
        {
            if (id != tbDoiTac.DoitacId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDoiTac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDoiTacExists(tbDoiTac.DoitacId))
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
            return View(tbDoiTac);
        }

        // GET: TbDoiTacs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDoiTac = await _context.TbDoiTac
                .FirstOrDefaultAsync(m => m.DoitacId == id);
            if (tbDoiTac == null)
            {
                return NotFound();
            }

            return View(tbDoiTac);
        }

        // POST: TbDoiTacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDoiTac = await _context.TbDoiTac.FindAsync(id);
            _context.TbDoiTac.Remove(tbDoiTac);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDoiTacExists(int id)
        {
            return _context.TbDoiTac.Any(e => e.DoitacId == id);
        }
    }
}
