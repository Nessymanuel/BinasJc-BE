using BinasJc.DAL.Context;
using BinasJc.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class PontoController : ControllerBase
{
    private readonly BinasJcContext _context;

    public PontoController(BinasJcContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetPontos()
    {
        var pontos = await _context.Pontos.ToListAsync();
        return Ok(pontos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPontoById(int id)
    {
        var ponto = await _context.Pontos.FindAsync(id);
        if (ponto == null)
        {
            return NotFound();
        }
        return Ok(ponto);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePonto([FromBody] Ponto ponto)
    {
        if (ModelState.IsValid)
        {
            _context.Pontos.Add(ponto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPontoById), new { id = ponto.PontoID }, ponto);
        }
        return BadRequest(ModelState);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePonto(int id, [FromBody] Ponto updatedPonto)
    {
        if (id != updatedPonto.PontoID)
        {
            return BadRequest();
        }

        _context.Entry(updatedPonto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Pontos.Any(e => e.PontoID == id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePonto(int id)
    {
        var ponto = await _context.Pontos.FindAsync(id);
        if (ponto == null)
        {
            return NotFound();
        }

        _context.Pontos.Remove(ponto);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
