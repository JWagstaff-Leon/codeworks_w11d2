using System;
using w11d2.Services;
using w11d2.Models;
using Microsoft.AspNetCore.Mvc;

namespace w11d2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobsService _serv;

        public JobsController(JobsService serv)
        {
            _serv = serv;
        }

        [HttpPost]
        public ActionResult<Job> Create([FromBody] Job data)
        {
            try
            {
                Job created = _serv.Create(data);
                return Ok(created);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Job> Remove(int id)
        {
            try
            {
                Job removed = _serv.Remove(id);
                return Ok(removed);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}