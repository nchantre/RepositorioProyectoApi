using Inventario.Aplicacion.Comandos;
using Inventario.Aplicacion.Consultas;
using Inventario.Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Inventario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;


        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User request)
        {
            var command = new UserCommand(request);
            var result = await _mediator.Send(command);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);

        }


        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            var result = await _mediator.Send( new UserGetAllQuery());
            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id )
        {
            var result = await _mediator.Send(new UserGetByldQuery {  EmployeeNumber = id});
            return Ok(result);
        }


        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UserUpdateCommand value)
        {
            value.Request.EmployeeNumber = id;
            var result = await _mediator.Send(value);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);

        }

       [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _mediator.Send(new UserDeleteCommand { EmployeeNumber = id });

            if (!deleted)
                return NotFound($"No se encontró el propietario con Id = {id}");

            return Ok(new User { EmployeeNumber = id });
        }

    }
}
