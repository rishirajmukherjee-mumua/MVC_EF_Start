using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ClassMate> ClassMates { get; set; }
        public DbSet<SongGenre> SongGenres { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<IdealSaturday> IdealSaturdays { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<ClassMateFood> ClassMateFoods { get; set; }
        public DbSet<ClassMateVacation> ClassMateVacations { get; set; }
        public DbSet<IdealSaturdayClassMate> IdealSaturdayClassMates { get; set; }

    }
}