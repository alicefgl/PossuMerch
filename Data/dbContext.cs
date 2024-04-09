using Microsoft.EntityFrameworkCore;
using PossuMerch.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class dbContext  : IdentityDbContext<Utente>
{
    public dbContext(DbContextOptions<dbContext> options)
        :base(options)
        {

        }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
     => options.UseSqlite(@"Data Source=Data/PossuMerch.db");

    public DbSet<Utente> Utenti { get; set; }
    public DbSet<Prodotto> Prodotti { get; set; }
    public DbSet<PossuMerch.Data.Cart> Cart { get; set; } = default!;
    public DbSet<RigaCarrello> Carrello { get; set; }

    
}