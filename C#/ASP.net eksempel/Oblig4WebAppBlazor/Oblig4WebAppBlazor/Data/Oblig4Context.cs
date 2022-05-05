using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Oblig4WebAppBlazor.Models;

namespace Oblig4WebAppBlazor.Data
{
    public class Oblig4Context : DbContext
    {
        public Oblig4Context(DbContextOptions<Oblig4Context> options)
            : base(options)
        {
            

        }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Room> rooms { get; set; }
    }
}