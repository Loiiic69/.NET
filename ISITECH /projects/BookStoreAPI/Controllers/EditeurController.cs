using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookStoreAPI.Entities;


[Route("api/[controller]")]
[ApiController]
public class EditeurController : ControllerBase
{
    private static List<Editeur> listeEditeurs = new List<Editeur>
    {
        new Editeur { Id = 1, Nom = "Éditions ABC", Adresse = "123 Rue Principale" },
        new Editeur { Id = 2, Nom = "Librairie XYZ", Adresse = "456 Avenue Secondaire" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Editeur>> Get()
    {
        return Ok(listeEditeurs);
    }

    [HttpGet("{id}")]
    public ActionResult<Editeur> Get(int id)
    {
        var editeur = listeEditeurs.Find(e => e.Id == id);

        if (editeur == null)
        {
            return NotFound();
        }

        return Ok(editeur);
    }

    [HttpPost]
    public ActionResult<Editeur> Post([FromBody] Editeur nouveauEditeur)
    {
        nouveauEditeur.Id = listeEditeurs.Count + 1;
        listeEditeurs.Add(nouveauEditeur);

        return CreatedAtAction(nameof(Get), new { id = nouveauEditeur.Id }, nouveauEditeur);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Editeur miseAJourEditeur)
    {
        var editeur = listeEditeurs.Find(e => e.Id == id);

        if (editeur == null)
        {
            return NotFound();
        }

        editeur.Nom = miseAJourEditeur.Nom;
        editeur.Adresse = miseAJourEditeur.Adresse;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var editeur = listeEditeurs.Find(e => e.Id == id);

        if (editeur == null)
        {
            return NotFound();
        }

        listeEditeurs.Remove(editeur);

        return NoContent();
    }
}
