using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JC.MyAirport.EF;

namespace MyAirportWebApi.Controllers
{
    /// <summary>
    /// Controller Bagage pour webAPI
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BagagesController : ControllerBase
    {
        private readonly MyAirportContext _context;

        /// <summary>
        /// Objet Bagage Controller
        /// </summary>
        public BagagesController(MyAirportContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Fonction Get Bagages
        /// GET: api/Bagages
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bagage>>> GetBagages()
        {
            return await _context.Bagages.ToListAsync();
        }

        /// <summary>
        /// Fonction Get Bagage
        /// GET: api/Bagages/5
        /// </summary>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Bagage>> GetBagage(int id)
        {
            var bagage = await _context.Bagages.FindAsync(id);

            if (bagage == null)
            {
                return NotFound();
            }

            return bagage;
        }


        /// <summary>
        /// Fonction PutBagage
        /// PUT: api/Bagages/5
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        /// more details see https://aka.ms/RazorPagesCRUD.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBagage(int id, Bagage bagage)
        {
            if (id != bagage.BagageId)
            {
                return BadRequest();
            }

            _context.Entry(bagage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BagageExists(id))
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

        /// <summary>
        /// Fonction Post Bagage
        /// POST: api/Bagages
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        /// more details see https://aka.ms/RazorPagesCRUD.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Bagage>> PostBagage(Bagage bagage)
        {
            _context.Bagages.Add(bagage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBagage", new { id = bagage.BagageId }, bagage);
        }

        /// <summary>
        /// Fonction Delete Bagage
        /// DELETE: api/Bagages/5
        /// </summary>

        [HttpDelete("{id}")]
        public async Task<ActionResult<Bagage>> DeleteBagage(int id)
        {
            var bagage = await _context.Bagages.FindAsync(id);
            if (bagage == null)
            {
                return NotFound();
            }

            _context.Bagages.Remove(bagage);
            await _context.SaveChangesAsync();

            return bagage;
        }

        private bool BagageExists(int id)
        {
            return _context.Bagages.Any(e => e.BagageId == id);
        }
    }
}
