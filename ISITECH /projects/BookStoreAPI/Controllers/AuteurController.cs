using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookStoreAPI.Entities;


[Route("api/[controller]")]
[ApiController]
public class AuteurController : ControllerBase
{
    private static List<Auteur> listeAuteurs = new List<Auteur>
    {
        new Auteur { Id = 1, Nom = "Jsp" },
        new Auteur { Id = 2, Nom = "Quoimettre" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Auteur>> Get()
    {
        return Ok(listeAuteurs);
    }

    [HttpGet("{id}")]
    public ActionResult<Auteur> Get(int id)
    {
        var auteur = listeAuteurs.Find(a => a.Id == id);

        if (auteur == null)
        {
            return NotFound(); 
        }

        return Ok(auteur);
    }

    [HttpPost]
    public ActionResult<Auteur> Post([FromBody] Auteur nouveauAuteur)
    {
        nouveauAuteur.Id = listeAuteurs.Count + 1;
        listeAuteurs.Add(nouveauAuteur);

        return CreatedAtAction(nameof(Get), new { id = nouveauAuteur.Id }, nouveauAuteur);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Auteur miseAJourAuteur)
    {
        var auteur = listeAuteurs.Find(a => a.Id == id);

        if (auteur == null)
        {
            return NotFound(); 
        }

        auteur.Nom = miseAJourAuteur.Nom;

        return NoContent(); 
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var auteur = listeAuteurs.Find(a => a.Id == id);

        if (auteur == null)
        {
            return NotFound(); 
        }

        listeAuteurs.Remove(auteur);

        return NoContent(); 
    }
}
