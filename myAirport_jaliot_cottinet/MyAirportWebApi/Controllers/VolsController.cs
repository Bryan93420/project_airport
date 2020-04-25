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
    /// Controller Vol pour webAPI
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VolsController : ControllerBase
    {
        private readonly MyAirportContext _context;

        /// <summary>
        /// Objet VolsController
        /// </summary>
        public VolsController(MyAirportContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Fonction GetVols
        /// GET: api/Vols
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vol>>> GetVols()
        {
            return await _context.Vols.ToListAsync();
        }
        /// <summary>
        /// Fonction GetVol
        /// GET: api/Vols/5?bool bagage
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Vol>> GetVol(int id, [FromQuery] bool bagages = false)
        {

            /*            var bag = await _context.Vols.Include(v => v.Bagages;
            */
            Vol volsRes;
            if (bagages)
            {
                volsRes = await _context.Vols.Include(v => v.Bagages).FirstAsync(v => v.VolId == id);
            }
            else
            {
                volsRes = await _context.Vols.FindAsync(id);
            }
            if (volsRes == null)
            {
                return NotFound();
            }
            return volsRes;


        }

        /// <summary>
        /// Fonction PutVol
        /// PUT: api/Vols/5
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        /// more details see https://aka.ms/RazorPagesCRUD.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVol(int id, Vol vol)
        {
            if (id != vol.VolId)
            {
                return BadRequest();
            }

            _context.Entry(vol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolExists(id))
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
        /// Fonction PostVol
        /// POST: api/Vols
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        /// more details see https://aka.ms/RazorPagesCRUD.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Vol>> PostVol(Vol vol)
        {
            _context.Vols.Add(vol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVol", new { id = vol.VolId }, vol);
        }

        /// <summary>
        /// Fonction DeleteVol
        /// DELETE: api/Vols/5
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vol>> DeleteVol(int id)
        {
            var vol = await _context.Vols.FindAsync(id);
            if (vol == null)
            {
                return NotFound();
            }

            _context.Vols.Remove(vol);
            await _context.SaveChangesAsync();

            return vol;
        }

        private bool VolExists(int id)
        {
            return _context.Vols.Any(e => e.VolId == id);
        }
    }
}
