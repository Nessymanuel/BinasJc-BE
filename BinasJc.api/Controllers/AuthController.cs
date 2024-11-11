using Microsoft.AspNetCore.Mvc;
using BinasJc.DAL.Context;
using BinasJc.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly BinasJcContext _context;

    public AuthController(BinasJcContext context)
    {
        _context = context;
    }

    // POST: api/Auth/Register
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] Usuario usuario)
    {
        // Verificar se o email já está registrado
        if (await _context.Usuarios.AnyAsync(u => u.Email == usuario.Email))
        {
            return BadRequest("Usuário já registrado com este email.");
        }

        // Adicionar o novo usuário
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Usuário registrado com sucesso" });
    }

    // POST: api/Auth/Login
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] Usuario usuario)
    {
        // Verificar se o usuário existe e se a senha está correta
        var user = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Email == usuario.Email && u.SenhaHash == usuario.SenhaHash);

        if (user == null)
        {
            return Unauthorized("Credenciais inválidas.");
        }

        // Retornar uma mensagem de sucesso com o ID do usuário ou outras informações
        return Ok(new { message = "Login realizado com sucesso", userId = user.UsuarioID });
    }
}

