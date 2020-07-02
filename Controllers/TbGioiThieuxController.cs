using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API.Sparta.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;

namespace API.Sparta.Controllers
{
    public class TbGioiThieuxController : Controller
    {
        private readonly DB_Context _context;

        public TbGioiThieuxController(DB_Context context)
        {
            _context = context;
        }

        // GET: TbGioiThieux1
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbGioiThieu.ToListAsync());
        }

        // GET: TbGioiThieux1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGioiThieu = await _context.TbGioiThieu
                .FirstOrDefaultAsync(m => m.GioithieuId == id);
            if (tbGioiThieu == null)
            {
                return NotFound();
            }

            return View(tbGioiThieu);
        }

        // GET: TbGioiThieux1/Create
        public IActionResult Create()
        {
            return View();
        }

        //GET: TbSlides/Search
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<TbGioiThieu>>> Searchtitle([FromQuery] string keys)
        {


            IQueryable<TbGioiThieu> bp = _context.TbGioiThieu;
            if (!string.IsNullOrEmpty(keys))
            {
                bp = bp.Where(x => x.GioithieuTieude.Contains(keys));
            }
            return await bp.ToListAsync();
        }

        // POST: TbGioiThieux1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbGioiThieu tbGioiThieu, IFormFile GioithieuHinhanh)
        {
            if (ModelState.IsValid)
            {
                if (GioithieuHinhanh.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(GioithieuHinhanh.ContentDisposition).FileName.Trim('"');
                    string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(GioithieuHinhanh.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\Uploadimages\\{ImageName}");
                    var pathView = $"\\Uploadimages\\{ImageName}";
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await GioithieuHinhanh.CopyToAsync(stream);
                    }
                    tbGioiThieu.GioithieuHinhanh = pathView;
                    tbGioiThieu.GioithieuNgaytao = DateTime.Now;
                }

                _context.Add(tbGioiThieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbGioiThieu);
        }

        // GET: TbGioiThieux1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGioiThieu = await _context.TbGioiThieu.FindAsync(id);
            if (tbGioiThieu == null)
            {
                return NotFound();
            }
            return View(tbGioiThieu);
        }

        // POST: TbGioiThieux1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TbGioiThieu tbGioiThieu, IFormFile GioithieuHinhanh)
        {
            if (id != tbGioiThieu.GioithieuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (GioithieuHinhanh != null)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(GioithieuHinhanh.ContentDisposition).FileName.Trim('"');
                    string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(GioithieuHinhanh.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\Uploadimages\\{ImageName}");
                    var pathView = $"\\Uploadimages\\{ImageName}";
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await GioithieuHinhanh.CopyToAsync(stream);
                    }
                    tbGioiThieu.GioithieuHinhanh = pathView;

                }
                try
                {
                    _context.Update(tbGioiThieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbGioiThieuExists(tbGioiThieu.GioithieuId))
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
            return View(tbGioiThieu);
        }

        // GET: TbGioiThieux1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGioiThieu = await _context.TbGioiThieu
                .FirstOrDefaultAsync(m => m.GioithieuId == id);
            if (tbGioiThieu == null)
            {
                return NotFound();
            }

            return View(tbGioiThieu);
        }

        // POST: TbGioiThieux1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbGioiThieu = await _context.TbGioiThieu.FindAsync(id);
            string fileName = "";

            if (tbGioiThieu != null)
            {

                fileName = tbGioiThieu.GioithieuHinhanh;
                var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{fileName}");
                if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
                //return NotFound();
            }
            _context.TbGioiThieu.Remove(tbGioiThieu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbGioiThieuExists(int id)
        {
            return _context.TbGioiThieu.Any(e => e.GioithieuId == id);
        }
    }
}
