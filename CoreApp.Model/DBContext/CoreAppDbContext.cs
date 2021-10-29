using CoreApp.Model.Entity;
using Microsoft.EntityFrameworkCore;


namespace CoreApp.Model.DBContext
{
    public class CoreAppDbContext : DbContext
    {
        public CoreAppDbContext() : base()
        {
            
        }

        public CoreAppDbContext(DbContextOptions<CoreAppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<BookingOffice> BookingOffices { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<PackingLot> PackingLotS { get; set; }
        public DbSet<Trip> TripS { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.UseSqlServer(@"server=DESKTOP-615AFDK;database=CarPack;trusted_connection=true;");
        }

    }
}
