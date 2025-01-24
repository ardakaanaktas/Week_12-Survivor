using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survivor.Data;

namespace Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _database;

        public CategoryController(ApplicationDbContext database)
        {
            _database = database;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_database.Categories.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var category = _database.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Data.Entities.Category category)
        {
            _database.Categories.Add(category);
            _database.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Data.Entities.Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            _database.Update(category);
            _database.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var category = _database.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _database.Categories.Remove(category);
            _database.SaveChanges();
            return NoContent();
        }
    }
}
