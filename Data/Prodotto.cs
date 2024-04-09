using System.ComponentModel.DataAnnotations;
namespace PossuMerch.Data;

public class Prodotto
{
    [Key]
    public int idProdotto { get; set; }
    public string? _NomeP { get; set; }
    public string? Descrizione { get; set; }
    public int? Quantita { get; set; } 
    public Tipo TipoP { get; set; }
    public float Prezzo { get; set; }
    public int idUser { get; set; }
    public enum Tipo{
        Chitarra,
        Basso
    }
}