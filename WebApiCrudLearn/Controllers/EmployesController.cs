using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCrudLearn.Models;
using WebApiCrudLearn.Repository;

namespace WebApiCrudLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployesController : ControllerBase
    {
        private readonly IRepositoryEmploye _employeRepository;

        public EmployesController(IRepositoryEmploye repositoryEmploye)
        {
            this._employeRepository = repositoryEmploye;
        }

        // api/employes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employe>>> GetEmployes()
        {
            IEnumerable<Employe> employes = await this._employeRepository.FindAllAsync();
            return Ok(employes);
        }

        // api/employes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Employe>> Get(int id)
        {
            Employe employe = await this._employeRepository.GetAsync(id);
            if(employe == null)
            {
                return NotFound();
            }
            return Ok(employe);
        }

        [HttpPost]
        public async Task<ActionResult<Employe>> Create([FromBody] Employe employe)
        {
            if(employe == null)
            {
                return BadRequest("Employe object ot valid");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Object Mode");
            }

            Employe newEmploye = await this._employeRepository.CreateAsync(employe);
            return Ok(newEmploye);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employe>> Delete(int id)
        {
            Employe employe = await this._employeRepository.GetAsync(id);
            if(employe == null)
            {
                return NotFound("Object not found");
            }
            await this._employeRepository.DeleteAsync(employe);
            return Ok(employe);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employe>> Update(int id, [FromBody] Employe employe)
        {
            if(employe == null)
            {
                return BadRequest("employe object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid object");
            }
            Employe employeToUpdate = await this._employeRepository.GetAsync(id);
            if (employeToUpdate.Id != employe.Id)
            {
                return NotFound();
            }
            await this._employeRepository.UpdateAsync(employe);
            return Ok(employe);
        }
    }
}
