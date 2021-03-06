﻿using FirstLineTeam.CORE.Models;
using FirstLineTeam.DATA.Persistens;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace FirstLineTeam.API.Controllers
{
    public class CheckListTasksController : ApiController
    {
        CheckListTaskRepository repo = new CheckListTaskRepository();

        // GET api/<controller>
        public Task<IEnumerable<CheckListTask>> Get()
        {
            var result = repo.GetCheckListTasks();
            return result;
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var result = repo.FindbyId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]CheckListTask model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            repo.Create(model);
            return Ok();
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]CheckListTask model)
        {
            if (!ModelState.IsValid || id != model.IdCheckListTask)
            {
                return BadRequest(ModelState);
            }

            if (repo.FindbyId(id) == null)
            {
                return NotFound();
            }
            else
            {
                repo.Update(model);
                return Ok();
            }

        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            if (repo.FindbyId(id) == null)
            {
                return NotFound();
            }
            else
            {
                repo.Delete(id);
                return Ok();
            }
        }
    }
}
