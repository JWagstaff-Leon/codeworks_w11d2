using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using w11d2.Services;
using w11d2.Models;


namespace w11d2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly CompaniesService _serv;
        private readonly JobsService _jobServ;

        public CompaniesController(CompaniesService serv, JobsService jobServ)
        {
            _serv = serv;
            _jobServ = jobServ;
        }

        [HttpGet]
        public ActionResult<List<Company>> GetAll()
        {
            try
            {
                List<Company> found = _serv.GetAll();
                return Ok(found);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Company> GetById(int id)
        {
            try
            {
                Company found = _serv.GetById(id);
                return Ok(found);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/jobs")]
        public ActionResult<List<ContractorJobVM>> GetJobs(int id)
        {
            try
            {
                List<ContractorJobVM> found = _jobServ.GetByCompanyId(id);
                return Ok(found);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Company> Create([FromBody] Company data)
        {
            try
            {
                Company created = _serv.Create(data);
                return Ok(created);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Company> Edit(int id, [FromBody] Company update)
        {
            try
            {
                Company edited = _serv.Edit(update);
                return Ok(edited);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Company> Remove(int id)
        {
            try
            {
                Company removed = _serv.Remove(id);
                return Ok(removed);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}