using Microsoft.EntityFrameworkCore;

namespace BitOrcTraineeTest.Models
{
    public class EmployesContext : DbContext
    {
        public DbSet<Employes> Employes { get; set; }
        public EmployesContext(DbContextOptions options) : base(options) { }
    }
}
