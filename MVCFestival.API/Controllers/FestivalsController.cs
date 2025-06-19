using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFestival.DAL.Data;
using MVCFestival.DAL.Models;

namespace MVCFestival.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FestivalsController : ControllerBase
    {
        private readonly FestivalDbContext _context;

        public FestivalsController(FestivalDbContext context)
        {
            _context = context;
        }

        // GET: api/Festivals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Festival>>> GetFestivals()
        {
            return await _context.Festivals.ToListAsync();
        }

        // GET: api/Festivals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Festival>> GetFestival(int id)
        {
            var festival = await _context.Festivals.FindAsync(id);

            if (festival == null)
            {
                return NotFound();
            }

            return festival;
        }

        // PUT: api/Festivals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFestival(int id, Festival festival)
        {
            if (id != festival.Id)
            {
                return BadRequest();
            }

            _context.Entry(festival).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FestivalExists(id))
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

        // POST: api/Festivals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Festival>> PostFestival(Festival festival)
        {
            _context.Festivals.Add(festival);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFestival", new { id = festival.Id }, festival);
        }

        // DELETE: api/Festivals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFestival(int id)
        {
            var festival = await _context.Festivals.FindAsync(id);
            if (festival == null)
            {
                return NotFound();
            }

            _context.Festivals.Remove(festival);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FestivalExists(int id)
        {
            return _context.Festivals.Any(e => e.Id == id);
        }
    }
}
