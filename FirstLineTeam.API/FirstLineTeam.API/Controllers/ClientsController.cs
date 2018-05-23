using FirstLineTeam.CORE.Models;
using FirstLineTeam.DATA.Persistens;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace FirstLineTeam.API.Controllers
{
    public class ClientsController : ApiController
    {
        ClientRepository repo = new ClientRepository();

        // GET api/<controller>
        public async Task<IEnumerable<Client>> Get()
        {
            var result = await repo.GetClients();
            return result;
        }

        // GET api/<controller>/5
        public async Task<IHttpActionResult> Get(int id)
        {
            var result = await repo.FindbyId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<controller>
        public async Task<IHttpActionResult> Post([FromBody]Client model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    await repo.Create(model);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.ToString());
                }
            }
        }

        // PUT api/<controller>/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]Client model)
        {
            if (!ModelState.IsValid || id != model.IdClient)
            {
                return BadRequest(ModelState);
            }

            if (repo.FindbyId(id) == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    await repo.Update(model);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.ToString());
                }
            }

        }

        // DELETE api/<controller>/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (repo.FindbyId(id) == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    await repo.Delete(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.ToString());
                }
            }
        }
    }
}