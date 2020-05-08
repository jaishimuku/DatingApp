using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase // "ControllerBase" without view support; "Controller" with view support
    {
        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;
        }
        //GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();

            return Ok(values);
        }

        //GET api/values/
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value =  await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }
    }
}