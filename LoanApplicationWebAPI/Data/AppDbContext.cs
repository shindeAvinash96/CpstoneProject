using LoanApplicationWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanApplicationWebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LoanOfficer> LoanOfficers { get; set; }
        public DbSet<LoanAdmin> LoanAdmins { get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }
        public DbSet<LoanScheme> LoanSchemes { get; set; }
        public DbSet<LoanApproved> LoanApproved { get; set; }
        public DbSet<Repayment> Repayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TPH inheritance for User
            modelBuilder.Entity<User>()
                .HasDiscriminator(u => u.UserRoleType)
                .HasValue<Customer>(UserRole.Customer)
                .HasValue<LoanOfficer>(UserRole.Officer)
                .HasValue<LoanAdmin>(UserRole.Admin);

            // Cascade-safe FKs
            modelBuilder.Entity<LoanApplication>()
                .HasOne(la => la.Customer)
                .WithMany(c => c.LoanApplications)
                .HasForeignKey(la => la.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LoanApplication>()
                .HasOne(la => la.LoanOfficer)
                .WithMany(o => o.AssignedApplications)
                .HasForeignKey(la => la.LoanOfficerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LoanApplication>()
                .HasOne(la => la.LoanScheme)
                .WithMany(s => s.LoanApplications)
                .HasForeignKey(la => la.LoanSchemeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LoanApproved>()
                .HasOne(l => l.LoanApplication)
                .WithOne(la => la.LoanApproved)
                .HasForeignKey<LoanApproved>(l => l.LoanApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Repayment>()
                .HasOne(r => r.ApprovedLoan)
                .WithMany(l => l.Repayments)
                .HasForeignKey(r => r.ApprovedLoanId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed LoanAdmin
            modelBuilder.Entity<LoanAdmin>().HasData(
                new LoanAdmin
                {
                    UserId = 1,
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = "ADMIN_001",
                    Email = "admin@loanapp.com",
                    PasswordHash = "Admin@123",
                    UserRoleType = UserRole.Admin
                }
            );
        }
    }
}
