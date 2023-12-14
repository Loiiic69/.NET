using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookStoreAPI.Entities;


[Route("api/[controller]")]
[ApiController]
public class GenresController : ControllerBase
{
    private static List<Genres> listeGenres = new List<Genres>
    {
        new Genres { Id = 1, titre = "Roman" },
        new Genres { Id = 2, titre = "Science-Fiction" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Genres>> Get()
    {
        return Ok(listeGenres);
    }

    [HttpGet("{id}")]
    public ActionResult<Genres> Get(int id)
    {
        var genre = listeGenres.Find(g => g.Id == id);

        if (genre == null)
        {
            return NotFound();
        }

        return Ok(genre);
    }

    [HttpPost]
    public ActionResult<Genres> Post([FromBody] Genres nouveauGenre)
    {
        nouveauGenre.Id = listeGenres.Count + 1;
        listeGenres.Add(nouveauGenre);

        return CreatedAtAction(nameof(Get), new { id = nouveauGenre.Id }, nouveauGenre);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Genres miseAJourGenre)
    {
        var genre = listeGenres.Find(g => g.Id == id);

        if (genre == null)
        {
            return NotFound();
        }

        genre.titre = miseAJourGenre.titre;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var genre = listeGenres.Find(g => g.Id == id);

        if (genre == null)
        {
            return NotFound();
        }

        listeGenres.Remove(genre);

        return NoContent();
    }
}
