// Controllers/ReservaController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoworkingApi.Data;
using CoworkingApi.Models;

namespace CoworkingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly CoworkingContext _context;

        public ReservaController(CoworkingContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna a lista de todas as reservas existentes.
        /// </summary>
        /// <returns>Uma lista de objetos Reserva.</returns>
        /// <response code="200">Retorna a lista de reservas.</response>
        /// <response code="404">Não foram encontradas reservas.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservas()
        {
            var reservas = await _context.Reservas.ToListAsync();
            if (reservas == null || reservas.Count == 0)
            {
                return NotFound("Nenhuma reserva encontrada.");
            }
            return Ok(reservas);
        }

        /// <summary>
        /// Cria uma nova reserva.
        /// </summary>
        /// <param name="reserva">Objeto Reserva contendo os dados da nova reserva.</param>
        /// <returns>O objeto Reserva criado.</returns>
        /// <response code="201">Reserva criada com sucesso.</response>
        /// <response code="400">Se os dados fornecidos forem inválidos.</response>
        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva([FromBody] Reserva reserva)
        {
            if (reserva == null)
            {
                return BadRequest("Dados da reserva inválidos.");
            }

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReservas), new { id = reserva.Id }, reserva);
        }

        /// <summary>
        /// Deleta uma reserva específica pelo seu ID.
        /// </summary>
        /// <param name="id">ID da reserva a ser deletada.</param>
        /// <returns>Status da operação.</returns>
        /// <response code="204">Reserva deletada com sucesso.</response>
        /// <response code="404">Reserva não encontrada.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound($"Reserva com ID {id} não encontrada.");
            }

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
