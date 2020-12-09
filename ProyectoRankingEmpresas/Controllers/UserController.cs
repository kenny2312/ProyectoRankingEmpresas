using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoRankingEmpresas.Model;
using EntityModel.Dto;
using EntityModel.Dto.UserDto;
using Microsoft.EntityFrameworkCore;

using AutoMapper;
using EntityModel.MClass;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ProyectoRankingEmpresas.Jwt;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoRankingEmpresas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<ValuesController1>
        [Jwt.Authorize]
        [HttpGet]
        [Route("List")]
        [PermisoAttribute(Permiso = RolesPermisos.List_User)]
        public async Task<ActionResult<IEnumerable<DtoUser>>> Get()
        {
            //asuhdkhasjdjhakdhskasd
            var identity = HttpContext.User.Identity as ClaimsIdentity;
           
            IEnumerable<DtoUser> lista = await  _context.User.Select(p => new DtoUser
            {
                Guid=p.Guid,
                Name = p.Name,
                LastName = p.LastName
            }).ToListAsync();

            return Ok(lista);
        }

        // GET api/<ValuesController1>/5
        [HttpGet]
        [Route("User")]
        public async Task<ActionResult<DtoUser>> Get(string id)
        {
        
            var person = await _context.User.FindAsync(id);
            
            var dto =(DtoUser) _mapper.Map<DtoUser>(person);
            if (person == null)

            {
                return NotFound(id);
            }

            return Ok(dto);
        }

        // POST api/<ValuesController1>
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<HttpResponseMessage>> Post([FromBody] DtoUserCreate value)
        {
 
            try
            {
                var usermapp = _mapper.Map<UserSys>(value);
                usermapp.Guid = Guid.NewGuid().ToString();
                usermapp.CreationDate = DateTime.Now;
                _context.User.Add(usermapp);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return NotFound();
            }
            return Ok();
            

        }

        // PUT api/<ValuesController1>/5
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<HttpResponseMessage>> Put([FromBody] DtoUserUpdate value)
        {

            try
            {
                var useract = await _context.User.FindAsync(value.Guid);
                if (useract != null)
                {
                    var usermapp = _mapper.Map<UserSys>(value);
                    useract.Name = usermapp.Name;
                    useract.LastName = usermapp.LastName;
                    useract.Password = usermapp.Password;
                    useract.user = usermapp.user;
                    useract.GrupuserId = usermapp.GrupuserId;
                    await _context.SaveChangesAsync();
                }
                
                
               
              
            }
            catch (DbUpdateException ex)
            {
                return NotFound(value);
            }
            return Ok(value);


        }

        // DELETE api/<ValuesController1>/5
        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult<DtoUser>> Delete(string id)
        {

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user.user);



        }

        [NonAction]
        private bool PersonExists(string id)
        {
            return _context.User.Any(e => e.Guid == id);
        }
    }
}
