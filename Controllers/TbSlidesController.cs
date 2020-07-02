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
    public class TbSlidesController : Controller
    {
        private readonly DB_Context _context;

        public TbSlidesController(DB_Context context)
        {
            _context = context;
        }

        // GET: TbSlides
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbSlide.ToListAsync());
        }

        // GET: TbSlides/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSlide = await _context.TbSlide
                .FirstOrDefaultAsync(m => m.SlideId == id);
            if (tbSlide == null)
            {
                return NotFound();
            }

            return View(tbSlide);
        }

        // GET: TbSlides/Create
        public IActionResult Create()
        {
            return View();
        }

        //GET: TbSlides/Search
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<TbSlide>>> Searchtitle([FromQuery] string keys)
        {


            IQueryable<TbSlide> bp = _context.TbSlide;
            if (!string.IsNullOrEmpty(keys))
            {
                bp = bp.Where(x => x.SlideTieude.Contains(keys));
            }
            return await bp.ToListAsync();
        }

        // POST: TbSlides/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbSlide tbSlide, IFormFile SlideImage)
        {
            if (ModelState.IsValid)
            {

                if (SlideImage.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(SlideImage.ContentDisposition).FileName.Trim('"');
                    string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(SlideImage.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\Uploadimages\\{ImageName}");
                    var pathView = $"\\Uploadimages\\{ImageName}";
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await SlideImage.CopyToAsync(stream);
                    }
                    tbSlide.SlideImage = pathView;
                    //tbSlide.CamnangNgaytao = DateTime.Now;
                }

                _context.Add(tbSlide);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbSlide);
        }

        // GET: TbSlides/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSlide = await _context.TbSlide.FindAsync(id);
            if (tbSlide == null)
            {
                return NotFound();
            }
            return View(tbSlide);
        }

        // POST: TbSlides/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TbSlide tbSlide, IFormFile SlideImage)
        {
            if (id != tbSlide.SlideId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                if (SlideImage != null)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(SlideImage.ContentDisposition).FileName.Trim('"');
                    string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(SlideImage.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\Uploadimages\\{ImageName}");
                    var pathView = $"\\Uploadimages\\{ImageName}";
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await SlideImage.CopyToAsync(stream);
                    }
                    tbSlide.SlideImage = pathView;

                }
                try
                {
                    _context.Update(tbSlide);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbSlideExists(tbSlide.SlideId))
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
            return View(tbSlide);
        }

        // GET: TbSlides/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSlide = await _context.TbSlide
                .FirstOrDefaultAsync(m => m.SlideId == id);
            if (tbSlide == null)
            {
                return NotFound();
            }

            return View(tbSlide);
        }

        // POST: TbSlides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string fileName = "";
            var tbSlide = await _context.TbSlide.FindAsync(id);

            if (tbSlide != null)
            {

                fileName = tbSlide.SlideImage;
                var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{fileName}");
                if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
                //return NotFound();
            }

            _context.TbSlide.Remove(tbSlide);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbSlideExists(int id)
        {
            return _context.TbSlide.Any(e => e.SlideId == id);
        }
    }
}
