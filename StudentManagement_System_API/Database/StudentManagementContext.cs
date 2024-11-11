using Microsoft.EntityFrameworkCore;
using StudentManagement_System_API.Entity;



namespace StudentManagement_System_API.Database
{
    public class StudentManagementContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
        public DbSet<StudentContact> StudentContacts { get; set; }
        public DbSet<StudentEmail> StudentEmails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<EducationInfo> EducationInfos { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentResults> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define relationships between tables
            modelBuilder.Entity<Student>()
                .HasOne(s => s.User)
                .WithOne(u => u.Student)
                .HasForeignKey<User>(u => u.StudentUTNumber);

            modelBuilder.Entity<StudentAddress>()
                .HasOne(sa => sa.Student)
                .WithMany(s => s.Addresses)
                .HasForeignKey(sa => sa.StudentUTNumber);

            modelBuilder.Entity<StudentContact>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Contacts)
                .HasForeignKey(sc => sc.StudentUTNumber);

            modelBuilder.Entity<StudentEmail>()
                .HasOne(se => se.Student)
                .WithMany(s => s.Emails)
                .HasForeignKey(se => se.StudentUTNumber);

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Student)
                .WithMany(s => s.Images)
                .HasForeignKey(i => i.StudentUTNumber);

            modelBuilder.Entity<EducationInfo>()
                .HasOne(e => e.Student)
                .WithMany(s => s.EducationInfos)
                .HasForeignKey(e => e.StudentUTNumber);

            modelBuilder.Entity<StudentResults>()
                .HasOne(r => r.EducationInfo)
                .WithMany(e => e.StudentResults )
                .HasForeignKey(r => r.EducationInfoId);

            modelBuilder.Entity<EducationInfo>()
                .HasMany(e => e.Subjects)
                .WithMany(s => s.EducationInfos)
                .UsingEntity(join => join.ToTable("EducationInfoSubject"));
        }
    }

}
