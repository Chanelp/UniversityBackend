using UniversityApiBackend.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace UniversityApiBackend.DataAccess
{
    public class UniverityDBContext : DbContext
    {
        public UniverityDBContext(DbContextOptions<UniverityDBContext> options): base(options)
        {

        }

        // TODO: Add BdSets (Tables of our Data base)
        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }
    }
}
