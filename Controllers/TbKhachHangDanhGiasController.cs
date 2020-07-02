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
    public class TbKhachHangDanhGiasController : Controller
    {
        private readonly DB_Context _context;

        public TbKhachHangDanhGiasController(DB_Context context)
        {
            _context = context;
        }

        // GET: TbKhachHangDanhGias
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbKhachHangDanhGia.ToListAsync());
        }

        // GET: TbKhachHangDanhGias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhachHangDanhGia = await _context.TbKhachHangDanhGia
                .FirstOrDefaultAsync(m => m.KhachhangdanhgiaId == id);
            if (tbKhachHangDanhGia == null)
            {
                return NotFound();
            }

            return View(tbKhachHangDanhGia);
        }

        // GET: TbKhachHangDanhGias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbKhachHangDanhGias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbKhachHangDanhGia tbKhachHangDanhGia, IFormFile KhachhangdanhgiaHinhanh)
        {
            if (ModelState.IsValid)
            {
                if (KhachhangdanhgiaHinhanh != null)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(KhachhangdanhgiaHinhanh.ContentDisposition).FileName.Trim('"');
                    string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(KhachhangdanhgiaHinhanh.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\Uploadimages\\{ImageName}");
                    var pathView = $"\\Uploadimages\\{ImageName}";
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await KhachhangdanhgiaHinhanh.CopyToAsync(stream);
                    }
                    tbKhachHangDanhGia.KhachhangdanhgiaHinhanh = pathView;
                    //tbSlide.CamnangNgaytao = DateTime.Now;
                }
                _context.Add(tbKhachHangDanhGia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbKhachHangDanhGia);
        }

        // GET: TbKhachHangDanhGias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhachHangDanhGia = await _context.TbKhachHangDanhGia.FindAsync(id);
            if (tbKhachHangDanhGia == null)
            {
                return NotFound();
            }
            return View(tbKhachHangDanhGia);
        }

        // POST: TbKhachHangDanhGias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,TbKhachHangDanhGia tbKhachHangDanhGia, IFormFile KhachhangdanhgiaHinhanh)
        {
            if (id != tbKhachHangDanhGia.KhachhangdanhgiaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (KhachhangdanhgiaHinhanh != null)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(KhachhangdanhgiaHinhanh.ContentDisposition).FileName.Trim('"');
                    string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(KhachhangdanhgiaHinhanh.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\Uploadimages\\{ImageName}");
                    var pathView = $"\\Uploadimages\\{ImageName}";
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await KhachhangdanhgiaHinhanh.CopyToAsync(stream);
                    }
                    tbKhachHangDanhGia.KhachhangdanhgiaHinhanh = pathView;
                    //tbSlide.CamnangNgaytao = DateTime.Now;
                }
                try
                {
                    _context.Update(tbKhachHangDanhGia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbKhachHangDanhGiaExists(tbKhachHangDanhGia.KhachhangdanhgiaId))
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
            return View(tbKhachHangDanhGia);
        }

        // GET: TbKhachHangDanhGias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhachHangDanhGia = await _context.TbKhachHangDanhGia
                .FirstOrDefaultAsync(m => m.KhachhangdanhgiaId == id);
            if (tbKhachHangDanhGia == null)
            {
                return NotFound();
            }

            return View(tbKhachHangDanhGia);
        }

        // POST: TbKhachHangDanhGias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbKhachHangDanhGia = await _context.TbKhachHangDanhGia.FindAsync(id);
            string fileName = "";

            if (tbKhachHangDanhGia != null)
            {

                fileName = tbKhachHangDanhGia.KhachhangdanhgiaHinhanh;
                var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{fileName}");
                if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
                //return NotFound();
            }
            _context.TbKhachHangDanhGia.Remove(tbKhachHangDanhGia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbKhachHangDanhGiaExists(int id)
        {
            return _context.TbKhachHangDanhGia.Any(e => e.KhachhangdanhgiaId == id);
        }
    }
}
