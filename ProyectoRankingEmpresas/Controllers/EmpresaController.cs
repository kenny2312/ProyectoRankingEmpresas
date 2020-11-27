using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using EntityModel.Dto.EmpresaDto;
using EntityModel.MClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoRankingEmpresas.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoRankingEmpresas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public EmpresaController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<EmpresaController>
        [HttpGet]
        [Route("Empresa")]
        public async Task<ActionResult<DtoEmpresa>> Get(string id)
        {

            var company = await _context.Empresa.FindAsync(id);

            var dto = (DtoEmpresa)_mapper.Map<DtoEmpresa>(company);
            if (company == null)

            {
                return NotFound(id);
            }

            return Ok(dto);
        }
        // GET api/<EmpresaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmpresaController>
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<HttpResponseMessage>> Post([FromBody] DtoEmpresaCreate value)
        {

            try
            {
                var empresamapp = _mapper.Map<Empresa>(value);
                empresamapp.Guid = Guid.NewGuid().ToString();
                empresamapp.Guid = Guid.NewGuid().ToString();
                empresamapp.Guid = Guid.NewGuid().ToString();
                empresamapp.Guid = Guid.NewGuid().ToString();
                empresamapp.Guid = Guid.NewGuid().ToString();
                _context.Empresa.Add(empresamapp);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return NotFound();
            }
            return Ok();


        }

        // PUT api/<EmpresaController>/5
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<HttpResponseMessage>> Put([FromBody] DtoEmpresaUpdate value)
        {

            try
            {
                var empresaact = await _context.Empresa.FindAsync(value.Guid);
                if (empresaact != null)
                {
                    var empresamapp = _mapper.Map<Empresa>(value);
                    empresaact.Name = empresamapp.Name;
                    empresaact.Address = empresamapp.Address;
                    empresaact.City = empresamapp.City;
                    empresaact.Postal_code = empresamapp.Postal_code;
                    empresaact.Phone = empresamapp.Phone;
                    await _context.SaveChangesAsync();
                }




            }
            catch (DbUpdateException ex)
            {
                return NotFound(value);
            }
            return Ok(value);


        }
        // DELETE api/<EmpresaController>/5
        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult<DtoEmpresa>> Delete(string id)
        {

            var empresa  = await _context.Empresa.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }

            _context.Empresa.Remove(empresa);
            await _context.SaveChangesAsync();

            return Ok(empresa.empresa);



        }

        [NonAction]
        private bool PersonExists(string id)
        {
            return _context.User.Any(e => e.Guid == id);
        }
    }
}
