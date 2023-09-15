using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using advice_generator_app_api.Models;

namespace advice_generator_app_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceItemsController : ControllerBase
    {
        private readonly AdviceItemContext _context;

        public AdviceItemsController(AdviceItemContext context)
        {
            _context = context;
        }

        // GET: api/AdviceItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdviceItem>>> GetAdviceItems()
        {
          if (_context.AdviceItems == null)
          {
              return NotFound();
          }
            return await _context.AdviceItems.ToListAsync();
        }

        // GET: api/AdviceItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdviceItem>> GetAdviceItem(int id)
        {
          if (_context.AdviceItems == null)
          {
              return NotFound();
          }
            var adviceItem = await _context.AdviceItems.FindAsync(id);

            if (adviceItem == null)
            {
                return NotFound();
            }

            return adviceItem;
        }

        // PUT: api/AdviceItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdviceItem(int id, AdviceItem adviceItem)
        {
            if (id != adviceItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(adviceItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdviceItemExists(id))
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

        // POST: api/AdviceItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdviceItem>> PostAdviceItem(AdviceItem adviceItem)
        {
          if (_context.AdviceItems == null)
          {
              return Problem("Entity set 'AdviceItemContext.AdviceItems'  is null.");
          }
            _context.AdviceItems.Add(adviceItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdviceItem", new { id = adviceItem.Id }, adviceItem);
        }

        // DELETE: api/AdviceItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdviceItem(int id)
        {
            if (_context.AdviceItems == null)
            {
                return NotFound();
            }
            var adviceItem = await _context.AdviceItems.FindAsync(id);
            if (adviceItem == null)
            {
                return NotFound();
            }

            _context.AdviceItems.Remove(adviceItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdviceItemExists(int id)
        {
            return (_context.AdviceItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
