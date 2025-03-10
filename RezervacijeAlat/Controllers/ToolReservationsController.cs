using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RezervacijeAlat.Model;

namespace RezervacijeAlat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolReservationsController : Controller
    {
        private readonly ToolReservationContext _context;

        public ToolReservationsController(ToolReservationContext context)
        {
            _context = context;
        }

        // GET: api/toolreservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToolReservation>>> GetToolReservations()
        {
            return await _context.ToolReservations.Include(tr => tr.Tool).ToListAsync();
        }
        // GET: api/toolreservations/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ToolReservation>> GetToolReservation(int id)
        {
            var reservation = await _context.ToolReservations.Include(tr => tr.Tool)
                                                              .FirstOrDefaultAsync(tr => tr.ID == id);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }
        // POST: api/toolreservations
        [HttpPost]
        public async Task<ActionResult<ToolReservation>> PostToolReservation(ToolReservation reservation)
        {
            var tool = await _context.Tools.FindAsync(reservation.ToolID);
            if (tool == null)
            {
                return NotFound("Tool not found.");
            }

            // Calculate TotalRentPrice
            var days = (reservation.DateReservationTo - reservation.DateReservationFrom).Days;
            reservation.TotalRentPrice = days * tool.PriceRentPerDay;

            _context.ToolReservations.Add(reservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetToolReservation), new { id = reservation.ID }, reservation);
        }
        // PUT: api/toolreservations/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToolReservation(int id, ToolReservation reservation)
        {
            if (id != reservation.ID)
            {
                return BadRequest();
            }

            // Find the associated tool to calculate the total rent price again
            var tool = await _context.Tools.FindAsync(reservation.ToolID);
            if (tool == null)
            {
                return NotFound("Tool not found.");
            }

            var days = (reservation.DateReservationTo - reservation.DateReservationFrom).Days;
            reservation.TotalRentPrice = days * tool.PriceRentPerDay;

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToolReservationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Reservation changed");
        }

        // DELETE: api/toolreservations/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToolReservation(int id)
        {
            var reservation = await _context.ToolReservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            _context.ToolReservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToolReservationExists(int id)
        {
            return _context.ToolReservations.Any(e => e.ID == id);
        }
    }


}

