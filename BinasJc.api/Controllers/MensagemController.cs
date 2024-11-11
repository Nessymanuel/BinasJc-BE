using BinasJc.DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class MensagensController : ControllerBase
{
    private readonly BinasJcContext _context;

    public MensagensController(BinasJcContext context)
    {
        _context = context;
    }

    [HttpGet("{usuarioId}")]
    public async Task<IActionResult> GetMensagens(int usuarioId)
    {
        var mensagens = await _context.Mensagem
            .Where(m => m.UsuarioRemetenteID == usuarioId || m.UsuarioDestinatarioID == usuarioId)
            .Include(m => m.Remetente)
            .Include(m => m.Destinatario)
            .ToListAsync();

        return Ok(mensagens);
    }
    [HttpPost]
    public async Task<IActionResult> EnviarMensagem([FromBody] Mensagem mensagem)
    {
        if (mensagem == null || string.IsNullOrWhiteSpace(mensagem.Conteudo))
        {
            return BadRequest("O conteúdo da mensagem é obrigatório.");
        }

        // Verifique se os IDs de remetente e destinatário existem no banco de dados
        var remetenteExiste = await _context.Usuarios.AnyAsync(u => u.UsuarioID == mensagem.UsuarioRemetenteID);
        var destinatarioExiste = await _context.Usuarios.AnyAsync(u => u.UsuarioID == mensagem.UsuarioDestinatarioID);

        if (!remetenteExiste)
        {
            return NotFound("Remetente não encontrado.");
        }

        if (!destinatarioExiste)
        {
            return NotFound("Destinatário não encontrado.");
        }

        // Adiciona a data de envio automaticamente se não for fornecida
        if (mensagem.DataEnvio == default)
        {
            mensagem.DataEnvio = DateTime.Now;
        }

        // Adiciona a mensagem ao contexto
        _context.Mensagem.Add(mensagem);
        await _context.SaveChangesAsync();

        return Ok(new { mensagemID = mensagem.MensagemID, mensagem.Conteudo, mensagem.DataEnvio });
    }



}
