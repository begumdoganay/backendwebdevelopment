using Microsoft.AspNetCore.Mvc;
using CrazyMusiciansAPI.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CrazyMusiciansAPI.Controllers
{

    // Controller for managing musician operations in the Crazy Musicians API

    [Route("api/[controller]")]
        [ApiController]
        public class MusiciansController : ControllerBase
        {
            // Static list of musicians serving as in-memory database
            private static List<Musician> _musicians =
        [
            new Musician {
                Id = 1,
                FullName = "Ahmet Çalgý",
                Occupation = "Ünlü Çalgý Çalar",
                Feature = "Her zaman yanlýþ nota çalar, ama çok eðlenceli",
                YearsActive = 5,
                FavoriteKey = "Am"
            },
            // Additional musicians can be added with new properties...
        ];


            // Retrieves all musicians from the database

            [HttpGet]
            public ActionResult<IEnumerable<Musician>> Get()
            {
                return _musicians.ToList();
            }

            // Retrieves a specific musician by their ID

            // <param name="id">The ID of the musician to retrieve</param>
            [HttpGet("{id:int:min(1)}")]
            public ActionResult<Musician> GetById(int id)
            {
                var musician = _musicians.FirstOrDefault(x => x.Id == id);
                return musician == null ? NotFound($"Musician with ID {id} not found.") : Ok(musician);
            }


            // Searches for musicians by name or surname

            // <param name="name">Name or surname to search for</param>
            [HttpGet("search")]
            public ActionResult<IEnumerable<Musician>> GetByName([FromQuery] string name)
            {
                if (string.IsNullOrWhiteSpace(name))
                    return BadRequest("Search name cannot be empty.");

                var musicians = _musicians
                    .Where(x => x.FullName.Split(" ")
                    .Any(part => part.Equals(name, StringComparison.OrdinalIgnoreCase)))
                    .ToList();

                return !musicians.Any() ? NotFound($"No musicians found matching '{name}'") : Ok(musicians);
            }


            // Creates a new musician
            // <param name="newMusician">The musician data to create</param>
            [HttpPost("post")]
            public ActionResult<Musician> Post([FromBody] Musician newMusician)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                newMusician.Id = _musicians.Max(x => x.Id) + 1;
                _musicians.Add(newMusician);

                return CreatedAtAction(nameof(GetById), new { id = newMusician.Id }, newMusician);
            }


            // Updates a musician's feature using JSON Patch

            // <param name="id">The ID of the musician to update</param>
            // <param name="patchDocument">The JSON patch document containing changes</param>
            [HttpPatch("feature/change/{id:int:min(1)}")]
            public IActionResult ChangeFeature(int id, [FromBody] JsonPatchDocument<Musician> patchDocument)
            {
                var musician = _musicians.FirstOrDefault(x => x.Id == id);
                if (musician == null)
                    return NotFound($"Musician with ID {id} not found.");

                try
                {
                    patchDocument.ApplyTo(musician, ModelState);
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    return NoContent();
                }
                catch (JsonPatchException)
                {
                    return BadRequest("Invalid patch document");
                }
            }


            // Updates a musician's name

            // <param name="id">The ID of the musician to update</param>
            // <param name="newName">The new name to set</param>
            [HttpPut("name/update/{id:int:min(1)}/{newName}")]
            public IActionResult UpdateName(int id, string newName)
            {
                var musician = _musicians.FirstOrDefault(x => x.Id == id);
                if (musician == null)
                    return NotFound($"Musician with ID {id} not found.");

                if (string.IsNullOrWhiteSpace(newName))
                    return BadRequest("New name cannot be empty.");

                musician.FullName = newName;
                return NoContent();
            }

            // Deletes a musician by ID
     
            // <param name="id">The ID of the musician to delete</param>
            [HttpDelete("{id:int:min(1)}")]
            public IActionResult DeleteMusician(int id)
            {
                var musicianToRemove = _musicians.FirstOrDefault(x => x.Id == id);
                if (musicianToRemove == null)
                    return NotFound($"Musician with ID {id} not found.");

                _musicians.Remove(musicianToRemove);
                return NoContent();
            }

            // Deletes musicians by name search
            // <param name="name">Name to search for deletion</param>
            [HttpDelete("delete/search")]
            public IActionResult DeleteByName([FromQuery] string name)
            {
                if (string.IsNullOrWhiteSpace(name))
                    return BadRequest("Search name cannot be empty.");

                var musiciansToRemove = _musicians
                    .Where(x => x.FullName.Split(' ')
                    .Any(part => part.Equals(name, StringComparison.OrdinalIgnoreCase)))
                    .ToList();

                if (!musiciansToRemove.Any())
                    return NotFound($"No musicians found matching '{name}'");

                foreach (var musician in musiciansToRemove)
                    _musicians.Remove(musician);

                return Ok($"Deleted {musiciansToRemove.Count} musicians");
            }
        }

    public class JsonPatchDocument<T>
    {
        internal void ApplyTo(Musician musician, ModelStateDictionary modelState)
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    internal class JsonPatchException : Exception
    {
        public JsonPatchException()
        {
        }

        public JsonPatchException(string? message) : base(message)
        {
        }

        public JsonPatchException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
    

