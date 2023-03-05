using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HBike.Models;
using HBike.DTOs;
using AutoMapper;

namespace HBike_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private IMapper Mapper { get; }

        private readonly HBikeContext _context;

        public StationController(HBikeContext context, IMapper mapper)
        {
            _context = context;
            this.Mapper = mapper;
        }

        // GET: api/Station
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationDTO>>> GetStations()
        {
            if (_context.Stations == null)
            {
                return NotFound();
            }
            return await _context.Stations
                .Select(s => Mapper.Map<StationDTO>(s))
                .ToListAsync();
        }

        // GET: api/Station/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StationDTO>> GetStation(long id)
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

            return Mapper.Map<StationDTO>(station);
        }

        // PUT: api/Station/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStation(long id, StationDTO stationDTO)
        {
            if (id != stationDTO.StationId)
            {
                return BadRequest();
            }

            var station = Mapper.Map<Station>(stationDTO);
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
        public async Task<ActionResult<StationDTO>> PostStation(StationDTO stationDTO)
        {
            if (_context.Stations == null)
            {
                return Problem("Entity set 'HBikeContext.Stations'  is null.");
            }

            // Ensure that user cannot set station ID
            var station = Mapper.Map<Station>(stationDTO);
            station.StationId = 0;

            _context.Stations.Add(station);
            await _context.SaveChangesAsync();

            // Assing the created ID to the returned DTO
            stationDTO.StationId = station.StationId;
            return CreatedAtAction("GetStation", new { id = station.StationId }, stationDTO);
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
