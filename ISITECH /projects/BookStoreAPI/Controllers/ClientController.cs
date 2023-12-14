using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookStoreAPI.Entities;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private static List<Client> listeClients = new List<Client>
    {
        new Client { Id = 1, Nom = "Doe", Prenom = "John", Email = "john.doe@example.com" },
        new Client { Id = 2, Nom = "Smith", Prenom = "Jane", Email = "jane.smith@example.com" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Client>> Get()
    {
        return Ok(listeClients);
    }

    [HttpGet("{id}")]
    public ActionResult<Client> Get(int id)
    {
        var client = listeClients.Find(c => c.Id == id);

        if (client == null)
        {
            return NotFound();
        }

        return Ok(client);
    }

    [HttpPost]
    public ActionResult<Client> Post([FromBody] Client nouveauClient)
    {
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        nouveauClient.Id = listeClients.Count + 1;
        listeClients.Add(nouveauClient);

        return CreatedAtAction(nameof(Get), new { id = nouveauClient.Id }, nouveauClient);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Client miseAJourClient)
    {
        var client = listeClients.Find(c => c.Id == id);

        if (client == null)
        {
            return NotFound();
        }

        client.Nom = miseAJourClient.Nom;
        client.Prenom = miseAJourClient.Prenom;
        client.Email = miseAJourClient.Email;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var client = listeClients.Find(c => c.Id == id);

        if (client == null)
        {
            return NotFound();
        }

        listeClients.Remove(client);

        return NoContent();
    }
}
