using FirstLineTeam.CORE.Models;
using FirstLineTeam.DATA.Config;
using FirstLineTeam.DATA.Persistens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstLineTeam.API.Controllers
{
    public class ClientsController : ApiController
    {
        FirstLineTeamDbContext context = new FirstLineTeamDbContext();
        ClientRepository repo = new ClientRepository();

        // GET api/<controller>
        public IEnumerable<Client> Get()
        {
            var result = repo.GetClients();
            return result;
        }

        // GET api/<controller>/5
        public Client Get(int id)
        {
            var result = repo.FindbyId(id);
            return result;
        }

        // POST api/<controller>
        public void Post([FromBody]Client model)
        {
            if (ModelState.IsValid)
            {
                repo.Create(model);
            }
            else
            {
                BadRequest("Hubo un error y no se pudo guardar la información.");
            }
        }

        // PUT api/<controller>/5
        public void Put(int? id, [FromBody]Client model)
        {
            if (id == null)
            {
                BadRequest("Error");
            }
            else if (repo.FindbyId(id) == null)
            {
                BadRequest("El Cliente no existe");
            }
            else
            {
                repo.Update(model);
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            if (id == null)
            {
                BadRequest("Error");
            }
            else if (repo.FindbyId(id) == null)
            {
                BadRequest("El Cliente no existe");
            }
            else
            {
                repo.Delete(id);
            }
        }
    }
}