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
    public class StationController : ControllerBase
    {
        private readonly HBikeContext _context;

        public StationController(HBikeContext context)
        {
            _context = context;
        }

        // GET: api/Station
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Station>>> GetStations()
        {
          if (_context.Stations == null)
          {
              return NotFound();
          }
            return await _context.Stations.ToListAsync();
        }

        // GET: api/Station/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Station>> GetStation(long id)
        {
          if (_context.Stations == null)
          {
              return NotFound();
          }
            var station = await _context.Stations.FindAsync(id);

            if (station == null)
            {
                return NotFound();
            }

            return station;
        }

        // PUT: api/Station/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStation(long id, Station station)
        {
            if (id != station.StationId)
            {
                return BadRequest();
            }

            _context.Entry(station).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationExists(id))
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

        // POST: api/Station
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Station>> PostStation(Station station)
        {
          if (_context.Stations == null)
          {
              return Problem("Entity set 'HBikeContext.Stations'  is null.");
          }
            _context.Stations.Add(station);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStation", new { id = station.StationId }, station);
        }

        // DELETE: api/Station/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStation(long id)
        {
            if (_context.Stations == null)
            {
                return NotFound();
            }
            var station = await _context.Stations.FindAsync(id);
            if (station == null)
            {
                return NotFound();
            }

            _context.Stations.Remove(station);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StationExists(long id)
        {
            return (_context.Stations?.Any(e => e.StationId == id)).GetValueOrDefault();
        }
    }
}
