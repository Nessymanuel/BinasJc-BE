using BinasJc.Model;

public class Mensagem
{
    public int MensagemID { get; set; }
    public int UsuarioRemetenteID { get; set; }
    public int UsuarioDestinatarioID { get; set; }
    public string Conteudo { get; set; }
    public DateTime DataEnvio { get; set; } = DateTime.Now;


    public Usuario Remetente { get; set; }
    public Usuario Destinatario { get; set; }
}
