using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RezervacijeAlat.Model;
using System.Linq;
using System.Threading.Tasks;

namespace RezervacijeAlat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController : Controller
    {
        private readonly ToolReservationContext _context;

        public ToolsController(ToolReservationContext context)
        {
            _context = context;
        }
        // GET: api/tools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tool>>> GetTools()
        {
            return await _context.Tools.Take(100).ToListAsync();
        }

        // GET: api/tools/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Tool>> GetTool(int id)
        {
            var tool = await _context.Tools.FindAsync(id);

            if (tool == null)
            {
                return NotFound();
            }

            return tool;
        }
 
}
