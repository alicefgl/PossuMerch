using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Add this using directive
using Microsoft.AspNetCore.Identity;

namespace PossuMerch.Data
{
    public class Cart
    {
        [Key]
        public string Id { get; set; } // Primary key of the cart

        [ForeignKey("Utenti")]
        public string IdUtente { get; set; } // Foreign key of the user

        [ForeignKey("Prodotti")]
        public string IdProdotto { get; set; } // Foreign key of the product
    }
}
