using advice_generator_app_api.Dto;
using advice_generator_app_api.Interfaces;
using advice_generator_app_api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace advice_generator_app_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceItemsController : ControllerBase
    {
        private readonly IAdviceItemRepository _adviceItemRepository;
        private readonly IMapper _mapper;

        public AdviceItemsController(IAdviceItemRepository adviceItemRepository, IMapper mapper)
        {
            _adviceItemRepository = adviceItemRepository;
            _mapper = mapper;
        }


        // GET: api/AdviceItems
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AdviceItem>), 200)]
        public IActionResult GetAdviceItems()
        {
            var AdviceItems = _mapper.Map<List<AdviceItemDto>>(_adviceItemRepository.GetAdviceItems());

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(AdviceItems);
        }


        // GET: api/AdviceItems/5
        /*[HttpGet("{id:int}")]
        [ProducesResponseType(typeof(AdviceItem), 200)]
        [ProducesResponseType(400)]
        public IActionResult GetAdviceItem(int id)
        {
            if (!_adviceItemRepository.AdviceItemExists(id)) return NotFound();

            var adviceItem = _adviceItemRepository.GetAdviceItem(id);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(adviceItem);
        }*/


        // GET: api/AdviceItems/law1
        [HttpGet("{name}")]
        [ProducesResponseType(typeof(AdviceItem), 200)]
        [ProducesResponseType(400)]
        public IActionResult GetAdviceItem(string name)
        {
            if (!_adviceItemRepository.AdviceItemExists(name)) return NotFound();

            var adviceItem = _mapper.Map<AdviceItemDto>(_adviceItemRepository.GetAdviceItem(name));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(adviceItem);
        }


        // PUT: api/AdviceItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*
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
        */

        // POST: api/AdviceItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*
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
        */

        // DELETE: api/AdviceItems/5
        /*
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
        */

        /*
        private bool AdviceItemExists(int id)
        {
            return (_context.AdviceItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        */
    }
}
