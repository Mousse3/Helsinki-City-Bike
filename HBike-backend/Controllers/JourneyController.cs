using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HBike.Models;

namespace HBike_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly HBikeContext _context;

        public JourneyController(HBikeContext context)
        {
            _context = context;
        }

        // GET: api/Journey
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Journey>>> GetJourneys()
        {
            if (_context.Journeys == null)
            {
                return NotFound();
            }
            return await _context.Journeys.ToListAsync();
        }

        // GET: api/Journey/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Journey>> GetJourney(long id)
        {
            if (_context.Journeys == null)
            {
                return NotFound();
            }
            var journey = await _context.Journeys.FindAsync(id);

            if (journey == null)
            {
                return NotFound();
            }

            return journey;
        }

        // PUT: api/Journey/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJourney(long id, Journey journeyDTO)
        {
            if (id != journeyDTO.JourneyId)
            {
                return BadRequest();
            }

            var journey = await _context.Journeys.FindAsync(id);
            if (journey == null)
            {
                return NotFound();
            }

            // journey.Departure = journeyDTO.Departure;
            // journey.DepartureStation = journeyDTO.DepartureStation;


            _context.Entry(journeyDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JourneyExists(id))
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

        // POST: api/Journey
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Journey>> PostJourney(Journey journey)
        {
            if (_context.Journeys == null)
            {
                return Problem("Entity set 'HBikeContext.Journeys'  is null.");
            }
            _context.Journeys.Add(journey);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJourney", new { id = journey.JourneyId }, journey);
        }

        // DELETE: api/Journey/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJourney(long id)
        {
            if (_context.Journeys == null)
            {
                return NotFound();
            }
            var journey = await _context.Journeys.FindAsync(id);
            if (journey == null)
            {
                return NotFound();
            }

            _context.Journeys.Remove(journey);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JourneyExists(long id)
        {
            return (_context.Journeys?.Any(e => e.JourneyId == id)).GetValueOrDefault();
        }
    }
}
