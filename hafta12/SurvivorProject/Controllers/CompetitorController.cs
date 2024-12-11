using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurvivorProject.Model.Context;

namespace SurvivorProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorController : ControllerBase
    {
        private readonly SurvivorDbContext _context;

        public CompetitorController(SurvivorDbContext context)
        {
            _context = context;
        }

        // GET: api/competitors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Competitors>>> GetCompetitors()
        {
            return await _context.Competitors
                .Include(c => c.Category)
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        // GET: api/competitors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Competitors>> GetCompetitor(int id)
        {
            var competitor = await _context.Competitors
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

            if (competitor == null)
            {
                return NotFound();
            }

            return competitor;
        }

        // GET: api/competitors/categories/5
        [HttpGet("categories/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Competitors>>> GetCompetitorsByCategory(int categoryId)
        {
            var competitors = await _context.Competitors
                .Include(c => c.Category)
                .Where(c => c.CategoryId == categoryId && !c.IsDeleted)
                .ToListAsync();

            if (!competitors.Any())
            {
                return NotFound($"No competitors found for category ID: {categoryId}");
            }

            return competitors;
        }

        // POST: api/competitors
        [HttpPost]
        public async Task<ActionResult<Competitors>> CreateCompetitor(Competitors competitor)
        {
            // Kategori kontrolü
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == competitor.CategoryId && !c.IsDeleted);

            if (category == null)
            {
                return BadRequest("Invalid category ID");
            }

            _context.Competitors.Add(competitor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompetitor), new { id = competitor.Id }, competitor);
        }

        // PUT: api/competitors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompetitor(int id, Competitors competitor)
        {
            if (id != competitor.Id)
            {
                return BadRequest();
            }

            var existingCompetitor = await _context.Competitors
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

            if (existingCompetitor == null)
            {
                return NotFound();
            }

            // Kategori kontrolü
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == competitor.CategoryId && !c.IsDeleted);

            if (category == null)
            {
                return BadRequest("Invalid category ID");
            }

            existingCompetitor.FirstName = competitor.FirstName;
            existingCompetitor.LastName = competitor.LastName;
            existingCompetitor.Age = competitor.Age;
            existingCompetitor.City = competitor.City;
            existingCompetitor.CategoryId = competitor.CategoryId;
            existingCompetitor.UpdatedDate = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitorExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/competitors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetitor(int id)
        {
            var competitor = await _context.Competitors
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

            if (competitor == null)
            {
                return NotFound();
            }

            competitor.IsDeleted = true;
            competitor.UpdatedDate = DateTime.Now;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompetitorExists(int id)
        {
            return _context.Competitors.Any(e => e.Id == id && !e.IsDeleted);
        }
    }
}