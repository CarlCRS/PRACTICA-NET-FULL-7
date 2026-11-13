using Microsoft.AspNetCore.Mvc;
using WebAPI_Carlos_Chica_20261113.Entity;
using WebAPI_Carlos_Chica_20261113.Services;

namespace WebAPI_Carlos_Chica_20261113.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventoController(EventService evtSevice)
        {
            _eventService = evtSevice;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventos()
        {
            var eventos = await _eventService.ObtenertodosEventos();
            return Ok(eventos);
        }


        // GET api/<ValuesController>/
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> ObtenerPorId(int id)
        {
            try
            {
                var evento = await _eventService.ObtenerPorIdAsync(id);
                return Ok(evento);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<int>> Crear([FromBody] Evento evento)
        {
            try
            {
                var nuevoId = await _eventService.CrearAsync(evento);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoId }, new { id = nuevoId, mensaje = "Vuelo creado exitosamente" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Evento evento)
        {
            try
            {
                await _eventService.ActualizarAsync(evento);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _eventService.EliminarAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }
    }
}
