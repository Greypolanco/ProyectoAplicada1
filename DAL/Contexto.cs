using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext
{
    public DbSet<Ocupaciones> Ocupaciones {get; set;}
    public DbSet<Person> Person {get; set;}
    public DbSet<Lending> Lending {get; set;}
    public DbSet<Payments> Payment { get; set; }
    public Contexto (DbContextOptions<Contexto> options): base(options)
    {
    }
}