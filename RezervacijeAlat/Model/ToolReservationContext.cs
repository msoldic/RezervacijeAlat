using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RezervacijeAlat.Model
{
    public class ToolReservationContext : DbContext
    { 
        public DbSet<Tool> Tools { get; set; }
        public DbSet<ToolReservation> ToolReservations { get; set; }

        public ToolReservationContext(DbContextOptions<ToolReservationContext> options)
            : base(options)
        { }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //var connectionString = configuration.GetConnectionString("coreDB");
            optionsBuilder.UseSqlServer(
                //@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RezervacijeAlat;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"
                @"Data Source=irpsd2.dynu.net,51433;Initial Catalog=ReservationsTest;TrustServerCertificate=True;Persist Security Info=True;User ID=inrebus;Password=IR#PsD2;"
                );
            
        }*/

    }
}
