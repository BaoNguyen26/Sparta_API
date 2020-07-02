using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Sparta.Models;

namespace API.Sparta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbLoaiCamNangs1Controller : ControllerBase
    {
        private readonly DB_Context _context;

        public TbLoaiCamNangs1Controller(DB_Context context)
        {
            _context = context;
        }

        // GET: api/TbLoaiCamNangs1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbLoaiCamNang>>> GetTbLoaiCamNang()
        {
            return await _context.TbLoaiCamNang.ToListAsync();
        }

        // GET: api/TbLoaiCamNangs1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbLoaiCamNang>> GetTbLoaiCamNang(int id)
        {
            var tbLoaiCamNang = await _context.TbLoaiCamNang.FindAsync(id);

            if (tbLoaiCamNang == null)
            {
                return NotFound();
            }

            return tbLoaiCamNang;
        }

        // PUT: api/TbLoaiCamNangs1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbLoaiCamNang(int id, TbLoaiCamNang tbLoaiCamNang)
        {
            if (id != tbLoaiCamNang.LoaicamnangId)
            {
                return BadRequest();
            }

            _context.Entry(tbLoaiCamNang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbLoaiCamNangExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TbLoaiCamNangs1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TbLoaiCamNang>> PostTbLoaiCamNang(TbLoaiCamNang tbLoaiCamNang)
        {
            _context.TbLoaiCamNang.Add(tbLoaiCamNang);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbLoaiCamNang", new { id = tbLoaiCamNang.LoaicamnangId }, tbLoaiCamNang);
        }

        // DELETE: api/TbLoaiCamNangs1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbLoaiCamNang>> DeleteTbLoaiCamNang(int id)
        {
            var tbLoaiCamNang = await _context.TbLoaiCamNang.FindAsync(id);
            if (tbLoaiCamNang == null)
            {
                return NotFound();
            }

            _context.TbLoaiCamNang.Remove(tbLoaiCamNang);
            await _context.SaveChangesAsync();

            return tbLoaiCamNang;
        }

        private bool TbLoaiCamNangExists(int id)
        {
            return _context.TbLoaiCamNang.Any(e => e.LoaicamnangId == id);
        }
    }
}
