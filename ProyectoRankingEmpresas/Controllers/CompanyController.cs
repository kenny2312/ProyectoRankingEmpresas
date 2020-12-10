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
//asd
namespace ProyectoRankingEmpresas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CompanyController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<EmpresaController>
        [HttpGet]
        [Route("Company")]
        public async Task<ActionResult<DtoCargos>> Get(string id)
        {

            var company = await _context.Company.FindAsync(id);

            var dto = (DtoCargos)_mapper.Map<DtoCargos>(company);
            if (company == null)

            {
                return NotFound(id);
            }

            return Ok(dto);
        }
        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmpresaController>
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<HttpResponseMessage>> Post([FromBody] DtoCompanyCreate value)
        {

            try
            {
                var companymapp = _mapper.Map<Company>(value);
                companymapp.CreationDate = DateTime.Now;
                companymapp.Guid = Guid.NewGuid().ToString();
                 _context.Company.Add(companymapp);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return NotFound();
            }
            return Ok();


        }

        // PUT api/<CompanyController>/5
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<HttpResponseMessage>> Put([FromBody] DtoCompanyUpdate value)
        {

            try
            {
                var companyact = await _context.Company.FindAsync(value.Guid);
                if (companyact != null)
                {
                    var companymapp = _mapper.Map<Company>(value);
                    companyact.Code = companymapp.Code;
                    companyact.Name = companymapp.Name;
                    companyact.Address = companymapp.Address;
                    companyact.City = companymapp.City;
                    companyact.Phone = companymapp.Phone;
                    companyact.Industry = companymapp.Industry;
                    await _context.SaveChangesAsync();
                }




            }
            catch (DbUpdateException ex)
            {
                return NotFound(value);
            }
            return Ok(value);


        }
        // DELETE api/<CompanyController>/5
        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult<DtoCargos>> Delete(string id)
        {

            var company  = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Company.Remove(company);
            await _context.SaveChangesAsync();

            return Ok(company.Name);



        }

        [NonAction]
        private bool CompanyExists(string id)
        {
            return _context.Company.Any(e => e.Guid == id);
        }
    }
}
