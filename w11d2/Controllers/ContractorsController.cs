using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using w11d2.Services;
using w11d2.Models;


namespace w11d2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractorsController : ControllerBase
    {
        private readonly ContractorsService _serv;
        private readonly JobsService _jobServ;

        public ContractorsController(ContractorsService serv, JobsService jobServ)
        {
            _serv = serv;
            _jobServ = jobServ;
        }

        [HttpGet]
        public ActionResult<List<Contractor>> GetAll()
        {
            try
            {
                List<Contractor> found = _serv.GetAll();
                return Ok(found);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Contractor> GetById(int id)
        {
            try
            {
                Contractor found = _serv.GetById(id);
                return Ok(found);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/jobs")]
        public ActionResult<List<CompanyJobVM>> GetJobs(int id)
        {
            try
            {
                List<CompanyJobVM> found = _jobServ.GetByContractorId(id);
                return Ok(found);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Contractor> Create([FromBody] Contractor data)
        {
            try
            {
                Contractor created = _serv.Create(data);
                return Ok(created);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Contractor> Edit(int id, [FromBody] Contractor update)
        {
            try
            {
                Contractor edited = _serv.Edit(update);
                return Ok(edited);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Contractor> Remove(int id)
        {
            try
            {
                Contractor removed = _serv.Remove(id);
                return Ok(removed);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}