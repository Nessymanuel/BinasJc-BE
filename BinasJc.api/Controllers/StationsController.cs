using Microsoft.AspNetCore.Mvc;
using BinasJc.DAL; // Certifique-se de usar o namespace correto do contexto de dados
using BinasJc.Model; // Namespace dos modelos
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static System.Collections.Specialized.BitVector32;
using BinasJc.DAL.Context;

[ApiController]
[Route("api/[controller]")]
public class StationsController : ControllerBase
{
    private readonly BinasJcContext _context;

    public StationsController(BinasJcContext context)
    {
        _context = context;
    }

    // GET: api/Stations
    [HttpGet]
    public async Task<IActionResult> GetStations()
    {
        var estacoes = await _context.Estacoes.ToListAsync();
        return Ok(estacoes);
    }

    // GET: api/Stations/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStationById(int id)
    {
        var station = await _context.Estacoes.FindAsync(id);
        if (station == null)
        {
            return NotFound();
        }
        return Ok(station);
    }

    // POST: api/Stations
    [HttpPost]
    public async Task<IActionResult> CreateStation([FromBody] Estacao estacoes)
    {
        if (ModelState.IsValid)
        {
            _context.Estacoes.Add(estacoes);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStationById), new { id = estacoes.EstacaoID }, estacoes);
        }
        return BadRequest(ModelState);
    }

    // PUT: api/Stations/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStation(int id, [FromBody] Estacao updatedStation)
    {
        if (id != updatedStation.EstacaoID)
        {
            return BadRequest();
        }

        _context.Entry(updatedStation).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Estacoes.Any(e => e.EstacaoID == id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // DELETE: api/Stations/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStation(int id)
    {
        var station = await _context.Estacoes.FindAsync(id);
        if (station == null)
        {
            return NotFound();
        }

        _context.Estacoes.Remove(station);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
