using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using xyzR_Employee_API.Data;
using xyzR_Employee_API.Model;

namespace xyzR_Employee_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalariesController : ControllerBase
    {
        private readonly xyzR_Employee_APIContext _context;

        public SalariesController(xyzR_Employee_APIContext context)
        {
            _context = context;
        }

        // GET: api/Salaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salary>>> GetSalary()
        {
          if (_context.Salary == null)
          {
              return NotFound();
          }
            return await _context.Salary.ToListAsync();
        }

        // GET: api/Salaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salary>> GetSalary(int id)
        {
          if (_context.Salary == null)
          {
              return NotFound();
          }
            var salary = await _context.Salary.FindAsync(id);

            if (salary == null)
            {
                return NotFound();
            }

            return salary;
        }

        // PUT: api/Salaries/5
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalary(int id, Salary salary)
        {
            if (id != salary.Id)
            {
                return BadRequest();
            }

            _context.Entry(salary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryExists(id))
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

        // POST: api/Salaries
        
        [HttpPost]
        public async Task<ActionResult<Salary>> PostSalary(Salary salary)
        {
          if (_context.Salary == null)
          {
              return Problem("Entity set 'xyzR_Employee_APIContext.Salary'  is null.");
          }
            _context.Salary.Add(salary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalary", new { id = salary.Id }, salary);
        }

        // DELETE: api/Salaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalary(int id)
        {
            if (_context.Salary == null)
            {
                return NotFound();
            }
            var salary = await _context.Salary.FindAsync(id);
            if (salary == null)
            {
                return NotFound();
            }

            _context.Salary.Remove(salary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalaryExists(int id)
        {
            return (_context.Salary?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
