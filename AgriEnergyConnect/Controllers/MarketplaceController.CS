using AgriEnergyConnect.Data;
using AgriEnergyConnect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketplaceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MarketplaceController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Marketplace
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketplaceItem>>> GetMarketplaceItems()
        {
            return await _context.MarketplaceItems.ToListAsync();
        }

        // GET: api/Marketplace/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketplaceItem>> GetMarketplaceItem(int id)
        {
            var item = await _context.MarketplaceItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // POST: api/Marketplace
        [HttpPost]
        public async Task<ActionResult<MarketplaceItem>> PostMarketplaceItem(MarketplaceItem item)
        {
            _context.MarketplaceItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMarketplaceItem), new { id = item.Id }, item);
        }

        // PUT: api/Marketplace/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketplaceItem(int id, MarketplaceItem item)
        {
            if (id != item.Id)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.MarketplaceItems.Any(e => e.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Marketplace/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarketplaceItem(int id)
        {
            var item = await _context.MarketplaceItems.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.MarketplaceItems.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
