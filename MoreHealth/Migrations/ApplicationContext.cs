using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MoreHealth.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Cabinet> Cabinet { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<PaidServices> PaidServices { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<WorkSchedule> WorkSchedule { get; set; }
        public DbSet<WorkingShift> WorkingShift { get; set; }
        public DbSet<WorkDate> WorkDate { get; set; }
    }
}