using BinasJc.DAL.Context;
using BinasJc.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class BicicletaController : ControllerBase
{
    private readonly BinasJcContext _context;

    public BicicletaController(BinasJcContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetBicicletas()
    {
        var bicicletas = await _context.Bicicletas.ToListAsync();
        return Ok(bicicletas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBicicletaById(int id)
    {
        var bicicleta = await _context.Bicicletas.FindAsync(id);
        if (bicicleta == null)
        {
            return NotFound();
        }
        return Ok(bicicleta);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBicicleta([FromBody] Bicicleta bicicleta)
    {
        if (ModelState.IsValid)
        {
            _context.Bicicletas.Add(bicicleta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBicicletaById), new { id = bicicleta.BicicletaID }, bicicleta);
        }
        return BadRequest(ModelState);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBicicleta(int id, [FromBody] Bicicleta updatedBicicleta)
    {
        if (id != updatedBicicleta.BicicletaID)
        {
            return BadRequest();
        }

        _context.Entry(updatedBicicleta).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Bicicletas.Any(e => e.BicicletaID == id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBicicleta(int id)
    {
        var bicicleta = await _context.Bicicletas.FindAsync(id);
        if (bicicleta == null)
        {
            return NotFound();
        }

        _context.Bicicletas.Remove(bicicleta);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
