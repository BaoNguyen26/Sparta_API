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
    public class TbCamNangsController : Controller
    {
        private readonly DB_Context _context;

        public TbCamNangsController(DB_Context context)
        {
            _context = context;
        }

        // GET: TbCamNangs
        public IActionResult Index()
        {
            IList<CamNang> studentList = new List<CamNang>();
            var student = (from tb in _context.TbCamNang
                           join lcn in _context.TbLoaiCamNang on tb.LoaicamnangId equals lcn.LoaicamnangId
                           select new
                           {
                               tb.CamnangId,
                               tb.CamnangTieude,
                               tb.CamnangMota,
                               tb.CamnangNoidung,
                               tb.CamnangHinhanh,
                               tb.LoaicamnangId,
                               lcn.LoaicamnangTieude,
                           }).ToList();
            foreach (var i in student)
            {
                studentList.Add(new CamNang() { CamnangId = i.CamnangId, CamnangTieude = i.CamnangTieude, CamnangMota = i.CamnangMota, CamnangHinhanh = i.CamnangHinhanh, CamnangNoidung = i.CamnangNoidung, LoaicamnangId = i.LoaicamnangId, LoaicamnangTieude = i.LoaicamnangTieude });
            }
            
            ViewData["students"] = studentList;

            return View();
        }

        // GET: TbCamNangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCamNang = await _context.TbCamNang
                .FirstOrDefaultAsync(m => m.CamnangId == id);
            if (tbCamNang == null)
            {
                return NotFound();
            }

            return View(tbCamNang);
        }

        // GET: TbCamNangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbCamNangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbCamNang tbCamNang, IFormFile CamnangHinhanh)
        {
            if (ModelState.IsValid)
            {
                if (CamnangHinhanh != null)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(CamnangHinhanh.ContentDisposition).FileName.Trim('"');
                    string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(CamnangHinhanh.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\Uploadimages\\{ImageName}");
                    var pathView = $"\\Uploadimages\\{ImageName}";
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await CamnangHinhanh.CopyToAsync(stream);
                    }
                    tbCamNang.CamnangHinhanh = pathView;
                    tbCamNang.CamnangNgaytao = DateTime.Now;
                }

                _context.Add(tbCamNang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            IList<CamNang> studentList = new List<CamNang>();
            var student = (from tb in _context.TbCamNang
                           join lcn in _context.TbLoaiCamNang on tb.LoaicamnangId equals lcn.LoaicamnangId
                           select new
                           {
                               tb.CamnangId,
                               tb.CamnangTieude,
                               tb.CamnangMota,
                               tb.CamnangNoidung,
                               tb.CamnangHinhanh,
                               tb.LoaicamnangId,
                               lcn.LoaicamnangTieude,
                           }).ToList();
            foreach (var i in student)
            {
                studentList.Add(new CamNang() { CamnangId = i.CamnangId, CamnangTieude = i.CamnangTieude, CamnangMota = i.CamnangMota, CamnangHinhanh = i.CamnangHinhanh, CamnangNoidung = i.CamnangNoidung, LoaicamnangId = i.LoaicamnangId, LoaicamnangTieude = i.LoaicamnangTieude });
            }

            ViewData["students"] = studentList;

            return View();
            //return View(tbCamNang);
        }

        // GET: TbCamNangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCamNang = await _context.TbCamNang.FindAsync(id);
            if (tbCamNang == null)
            {
                return NotFound();
            }
            return View(tbCamNang);
        }

        // POST: TbCamNangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TbCamNang tbCamNang, IFormFile CamnangHinhanh)
        {

            //    string fileName = "";
            //if (tbCamNang != null)
            //{

            //    fileName = tbCamNang.CamnangHinhanh;
            //    var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{fileName}");
            //    if (System.IO.File.Exists(path)) System.IO.File.Create(path);
            //    //return NotFound();
            //}
            //if (id != tbCamNang.CamnangId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                if (CamnangHinhanh != null)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(CamnangHinhanh.ContentDisposition).FileName.Trim('"');
                    string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(CamnangHinhanh.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\Uploadimages\\{ImageName}");
                    var pathView = $"\\Uploadimages\\{ImageName}";
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await CamnangHinhanh.CopyToAsync(stream);
                    }
                    tbCamNang.CamnangHinhanh = pathView;

                }
                //else
                //{
                //    var hinhanh = _context.TbCamNang.FirstOrDefault(x => x.CamnangId == id);
                //    string anhcu = hinhanh.CamnangHinhanh;
                //    tbCamNang.CamnangHinhanh = anhcu;
                //}
                try
                {
                    _context.Update(tbCamNang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbCamNangExists(tbCamNang.CamnangId))
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
            IList<CamNang> studentList = new List<CamNang>();
            var student = (from tb in _context.TbCamNang
                           join lcn in _context.TbLoaiCamNang on tb.LoaicamnangId equals lcn.LoaicamnangId
                           select new
                           {
                               tb.CamnangId,
                               tb.CamnangTieude,
                               tb.CamnangMota,
                               tb.CamnangNoidung,
                               tb.CamnangHinhanh,
                               tb.LoaicamnangId,
                               lcn.LoaicamnangTieude,
                           }).ToList();
            foreach (var i in student)
            {
                studentList.Add(new CamNang() { CamnangId = i.CamnangId, CamnangTieude = i.CamnangTieude, CamnangMota = i.CamnangMota, CamnangHinhanh = i.CamnangHinhanh, CamnangNoidung = i.CamnangNoidung, LoaicamnangId = i.LoaicamnangId, LoaicamnangTieude = i.LoaicamnangTieude });
            }

            ViewData["students"] = studentList;

            return View();
            //return View(tbCamNang);
        }

        // GET: TbCamNangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCamNang = await _context.TbCamNang
                .FirstOrDefaultAsync(m => m.CamnangId == id);
            if (tbCamNang == null)
            {
                return NotFound();
            }

            return View(tbCamNang);
        }

        // POST: TbCamNangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string fileName = "";
            //var fileName = ContentDispositionHeaderValue.Parse(CamnangHinhanh.ContentDisposition).FileName.Trim('"');
            //string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(CamnangHinhanh.FileName);
            //var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\Uploadimages\\{ImageName}");
            //var pathView = $"\\Uploadimages\\{ImageName}";
            //filename = HttpContext.Current.Server.MapPath("~" + filename);
            //if (System.IO.File.Exists(filename)) System.IO.File.Delete(filename);


            var tbCamNang = await _context.TbCamNang.FindAsync(id);

            //var tbCamNangimg = await _context.TbCamNang
            //    .FirstOrDefaultAsync(m => m.CamnangId == id);
            if (tbCamNang != null)
            {

                fileName = tbCamNang.CamnangHinhanh;
                var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{fileName}");
                if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
                //return NotFound();
            }

            _context.TbCamNang.Remove(tbCamNang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbCamNangExists(int id)
        {
            return _context.TbCamNang.Any(e => e.CamnangId == id);
        }
    }
}
