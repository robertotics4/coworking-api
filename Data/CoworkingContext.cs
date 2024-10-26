using Microsoft.EntityFrameworkCore;
using CoworkingApi.Models;

namespace CoworkingApi.Data;

public class CoworkingContext : DbContext
{
    public CoworkingContext(DbContextOptions<CoworkingContext> options) : base(options) { }

    public DbSet<Sala> Salas { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
}
