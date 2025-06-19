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
    public class FestivalStagesController : ControllerBase
    {
        private readonly FestivalDbContext _context;

        public FestivalStagesController(FestivalDbContext context)
        {
            _context = context;
        }

        // GET: api/FestivalStages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FestivalStage>>> GetFestivalStages()
        {
            return await _context.FestivalStages.ToListAsync();
        }

        // GET: api/FestivalStages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FestivalStage>> GetFestivalStage(int id)
        {
            var festivalStage = await _context.FestivalStages.FindAsync(id);

            if (festivalStage == null)
            {
                return NotFound();
            }

            return festivalStage;
        }

        // PUT: api/FestivalStages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFestivalStage(int id, FestivalStage festivalStage)
        {
            if (id != festivalStage.Id)
            {
                return BadRequest();
            }

            _context.Entry(festivalStage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FestivalStageExists(id))
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

        // POST: api/FestivalStages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FestivalStage>> PostFestivalStage(FestivalStage festivalStage)
        {
            _context.FestivalStages.Add(festivalStage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFestivalStage", new { id = festivalStage.Id }, festivalStage);
        }

        // DELETE: api/FestivalStages/5
        [HttpDelete("{stage}")]
        public async Task<IActionResult> DeleteFestivalStages(string stage)
        {
            var festivalStages = await _context.FestivalStages.Where(a => a.Name.Contains(stage)).ToListAsync();
            if (festivalStages == null || festivalStages.Count == 0)
            {
                return NotFound();
            }

            _context.FestivalStages.RemoveRange(festivalStages);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FestivalStageExists(int id)
        {
            return _context.FestivalStages.Any(e => e.Id == id);
        }
    }
}
