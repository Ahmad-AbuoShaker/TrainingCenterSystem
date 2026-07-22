using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TrainingCenterSystem.Entities;

namespace TrainingCenterSystem.DAL;

public partial class TrainingCenterDbContext : DbContext
{
    public TrainingCenterDbContext()
    {
    }

    public TrainingCenterDbContext(DbContextOptions<TrainingCenterDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }


  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasQueryFilter(p => !p.IsDeleted);
            entity.HasKey(e => e.PersonID);
           
            entity.Property(p=>p.Name).IsRequired().HasMaxLength(150);
            entity.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(20);

          
            entity.HasIndex(e => e.PhoneNumber).IsUnique();
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasQueryFilter(p => !p.IsDeleted);

            entity.HasKey(e => e.PersonID);

            entity.HasOne(e => e.Person)
                .WithOne(e => e.Student)
                .HasForeignKey<Student>(e => e.PersonID);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasQueryFilter(p => !p.IsDeleted);

            entity.HasKey(e => e.PersonID);

            entity.HasOne(e => e.Person)
                .WithOne(e => e.Employee)
                .HasForeignKey<Employee>(e => e.PersonID);

            entity.HasOne(e => e.Manager)
                .WithMany(e => e.Subordinates)
                .HasForeignKey(e => e.ManagerID)
                .OnDelete(DeleteBehavior.NoAction);

            entity.Property(e => e.JobTitle)
      .IsRequired()
      .HasMaxLength(50);

            entity.Property(e => e.Status)
                  .IsRequired()
                  .HasMaxLength(20);

            entity.Property(e => e.Salary)
                  .HasPrecision(18, 2);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasQueryFilter(p => !p.IsDeleted);
            entity.HasKey(e => e.UserID);

            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(p => p.Email).HasMaxLength(150);
            entity.Property(p => p.UserName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(200);
            entity.HasIndex(e => e.PersonID).IsUnique();
            entity.HasIndex(e => e.UserName).IsUnique();

            entity.HasOne(e => e.Person)
                .WithOne(e => e.User)
                .HasForeignKey<User>(e => e.PersonID);


            entity.HasMany(u => u.Roles)
                  .WithMany(r => r.Users)
                  .UsingEntity(j => j.ToTable("UserRole"));

        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasQueryFilter(p => !p.IsDeleted);
            entity.HasKey(e => e.RoleID);

            entity.Property(p => p.RoleName).IsRequired().HasMaxLength(50);
            entity.HasIndex(e => e.RoleName).IsUnique();
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasQueryFilter(p => !p.IsDeleted);
            entity.HasKey(e => e.CourseID);

            entity.HasIndex(e => e.Code).IsUnique();

            entity.HasOne(e => e.Instructor)
                .WithMany(e => e.Courses)
                .HasForeignKey(e => e.InstructorID)
                .OnDelete(DeleteBehavior.NoAction);
            entity.Property(e => e.Title)
      .IsRequired()
      .HasMaxLength(150);

            entity.Property(e => e.Code)
                  .HasMaxLength(20);

            entity.Property(e => e.Status)
                  .HasMaxLength(20);

            entity.Property(e => e.Price)
                  .HasPrecision(18, 2);
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentID);

            entity.HasOne(e => e.Student)
                .WithMany(e => e.Enrollments)
                .HasForeignKey(e => e.StudentID);

            entity.HasOne(e => e.Course)
                .WithMany(e => e.Enrollments)
                .HasForeignKey(e => e.CourseID)
                .OnDelete(DeleteBehavior.Cascade);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}