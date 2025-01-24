using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survivor.Data;
using Survivor.Data.Entities;

namespace Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorsController : ControllerBase
    {
        private readonly ApplicationDbContext _database;

        public CompetitorsController(ApplicationDbContext database)
        {
            _database = database;
        }

        [HttpGet]
        public ActionResult<Competitors> Get()
        {
            return Ok(_database.Competitors.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Competitors> Get(int id)
        {
            var competitor = _database.Competitors.Find(id);
            if (competitor == null)
            {
                return NotFound();
            }
            return Ok(competitor);
        }

        [HttpGet("categories/{categoryId}")]
        public ActionResult<Competitors> GetByCategory(int categoryId)
        {
            return Ok(_database.Competitors.Where(e => e.CategoryId == categoryId).ToList());
        }

        [HttpPost]
        public ActionResult<Competitors> Post([FromBody] Competitors competitor)
        {
            _database.Competitors.Add(competitor);
            _database.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = competitor.Id }, competitor);
        }

        [HttpPut("{id}")]
        public ActionResult<Competitors> Put(int id, [FromBody] Competitors competitor)
        {
            if (id != competitor.Id)
            {
                return BadRequest();
            }
            _database.Entry(competitor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _database.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Competitors> Delete(int id)
        {
            var competitor = _database.Competitors.Find(id);
            if (competitor == null)
            {
                return NotFound();
            }
            _database.Competitors.Remove(competitor);
            _database.SaveChanges();
            return NoContent();
        }
    }
}
