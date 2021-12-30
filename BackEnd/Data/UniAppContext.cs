using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{
    public class UniAppContext:DbContext
    {
        public UniAppContext(DbContextOptions<UniAppContext> options) : base(options) { }
        public DbSet<Applications> Applications { get; set; }
        public DbSet<SiteUser> SiteUsers { get; set; }
        public DbSet<AcademicProgram> AcademicProgram { get; set; }
    }
}
