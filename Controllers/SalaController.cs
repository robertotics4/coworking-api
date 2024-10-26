// Controllers/SalaController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoworkingApi.Data;
using CoworkingApi.Models;

namespace CoworkingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly CoworkingContext _context;

        public SalaController(CoworkingContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna a lista de todas as salas disponíveis e ocupadas.
        /// </summary>
        /// <returns>Uma lista de objetos Sala.</returns>
        /// <response code="200">Retorna a lista de salas.</response>
        /// <response code="404">Não foram encontradas salas.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sala>>> GetSalas()
        {
            var salas = await _context.Salas.ToListAsync();
            if (salas == null || salas.Count == 0)
            {
                return NotFound("Nenhuma sala encontrada.");
            }
            return Ok(salas);
        }

        /// <summary>
        /// Retorna uma sala específica pelo seu ID.
        /// </summary>
        /// <param name="id">ID da sala desejada.</param>
        /// <returns>O objeto Sala correspondente ao ID.</returns>
        /// <response code="200">Retorna a sala encontrada.</response>
        /// <response code="404">Sala não encontrada.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Sala>> GetSala(int id)
        {
            var sala = await _context.Salas.FindAsync(id);
            if (sala == null)
            {
                return NotFound($"Sala com ID {id} não encontrada.");
            }
            return Ok(sala);
        }

        /// <summary>
        /// Cria uma nova sala.
        /// </summary>
        /// <param name="sala">Objeto Sala contendo os dados da nova sala.</param>
        /// <returns>O objeto Sala criado.</returns>
        /// <response code="201">Sala criada com sucesso.</response>
        /// <response code="400">Se os dados fornecidos forem inválidos.</response>
        [HttpPost]
        public async Task<ActionResult<Sala>> PostSala([FromBody] Sala sala)
        {
            if (sala == null)
            {
                return BadRequest("Dados da sala inválidos.");
            }

            _context.Salas.Add(sala);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSala), new { id = sala.Id }, sala);
        }

        /// <summary>
        /// Deleta uma sala específica pelo seu ID.
        /// </summary>
        /// <param name="id">ID da sala a ser deletada.</param>
        /// <returns>Status da operação.</returns>
        /// <response code="204">Sala deletada com sucesso.</response>
        /// <response code="404">Sala não encontrada.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSala(int id)
        {
            var sala = await _context.Salas.FindAsync(id);
            if (sala == null)
            {
                return NotFound($"Sala com ID {id} não encontrada.");
            }

            _context.Salas.Remove(sala);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
