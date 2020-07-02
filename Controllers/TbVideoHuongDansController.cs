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
using System.Web;

namespace API.Sparta.Controllers
{
    public class TbVideoHuongDansController : Controller
    {
        private readonly DB_Context _context;

        public TbVideoHuongDansController(DB_Context context)
        {
            _context = context;
        }

        // GET: TbVideoHuongDans
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbVideoHuongDan.ToListAsync());
        }

        // GET: TbVideoHuongDans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVideoHuongDan = await _context.TbVideoHuongDan
                .FirstOrDefaultAsync(m => m.VideohuongdanId == id);
            if (tbVideoHuongDan == null)
            {
                return NotFound();
            }

            return View(tbVideoHuongDan);
        }

        // GET: TbVideoHuongDans/Create
        public IActionResult Create()
        {
            return View();
        }
        

        // POST: TbVideoHuongDans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbVideoHuongDan tbVideoHuongDan,IFormFile VideohuongdanHinhanh)
        {
            if (ModelState.IsValid)
            {
                if (VideohuongdanHinhanh.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(VideohuongdanHinhanh.ContentDisposition).FileName.Trim('"');
                    string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(VideohuongdanHinhanh.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\Uploadimages\\{ImageName}");
                    var pathView = $"\\Uploadimages\\{ImageName}";
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await VideohuongdanHinhanh.CopyToAsync(stream);
                    }
                    tbVideoHuongDan.VideohuongdanHinhanh = pathView;
                    //tbSlide.CamnangNgaytao = DateTime.Now;
                }
                _context.Add(tbVideoHuongDan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbVideoHuongDan);
        }

        // GET: TbVideoHuongDans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVideoHuongDan = await _context.TbVideoHuongDan.FindAsync(id);
            if (tbVideoHuongDan == null)
            {
                return NotFound();
            }
            return View(tbVideoHuongDan);
        }

        // POST: TbVideoHuongDans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VideohuongdanId,VideohuongdanTieude,VideohuongdanHinhanh,VideohuongdanLinkvideo")] TbVideoHuongDan tbVideoHuongDan)
        {
            if (id != tbVideoHuongDan.VideohuongdanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbVideoHuongDan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbVideoHuongDanExists(tbVideoHuongDan.VideohuongdanId))
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
            return View(tbVideoHuongDan);
        }

        // GET: TbVideoHuongDans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVideoHuongDan = await _context.TbVideoHuongDan
                .FirstOrDefaultAsync(m => m.VideohuongdanId == id);
            if (tbVideoHuongDan == null)
            {
                return NotFound();
            }

            return View(tbVideoHuongDan);
        }

        // POST: TbVideoHuongDans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbVideoHuongDan = await _context.TbVideoHuongDan.FindAsync(id);
            _context.TbVideoHuongDan.Remove(tbVideoHuongDan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbVideoHuongDanExists(int id)
        {
            return _context.TbVideoHuongDan.Any(e => e.VideohuongdanId == id);
        }
    }
}
