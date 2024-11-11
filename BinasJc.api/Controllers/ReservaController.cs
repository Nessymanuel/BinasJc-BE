using BinasJc.DAL.Context;
using BinasJc.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ReservaController : ControllerBase
{
    private readonly BinasJcContext _context;

    public ReservaController(BinasJcContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetReservas()
    {
        var reservas = await _context.Reservas.ToListAsync();
        return Ok(reservas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetReservaById(int id)
    {
        var reserva = await _context.Reservas.FindAsync(id);
        if (reserva == null)
        {
            return NotFound();
        }
        return Ok(reserva);
    }

    [HttpPost]
    public async Task<IActionResult> CreateReserva([FromBody] Reserva reserva)
    {
        if (ModelState.IsValid)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReservaById), new { id = reserva.ReservaID }, reserva);
        }
        return BadRequest(ModelState);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReserva(int id, [FromBody] Reserva updatedReserva)
    {
        if (id != updatedReserva.ReservaID)
        {
            return BadRequest();
        }

        _context.Entry(updatedReserva).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Reservas.Any(e => e.ReservaID == id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReserva(int id)
    {
        var reserva = await _context.Reservas.FindAsync(id);
        if (reserva == null)
        {
            return NotFound();
        }

        _context.Reservas.Remove(reserva);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
