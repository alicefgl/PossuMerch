using System.ComponentModel.DataAnnotations;
namespace PossuMerch.Data;

public class RigaCarrello
{
    [Key]
    public int? IdRigaCarrello { get; set; }
    public string? _NomeP { get; set; }
    public string? TipoP { get; set; }
    public float? Prezzo { get; set; }
    public string? UserName { get; set; }
    public int? Quantita { get; set; }
    public float? Totale { get{ return Prezzo * Quantita; }}
}