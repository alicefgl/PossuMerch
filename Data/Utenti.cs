using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace PossuMerch.Data;

public class Utente : IdentityUser
{
    [Key]
    public int idUtente { get; set; }
    public string? Email { get; set; } required
    public string? Nome { get; set; } required
    public string? Cognome { get; set; } required
    public DateTime DataDiNascita { get; set; } required
    public string? Password{ get; set;  } required
    public bool NewsLetter { get; set; }
}