using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HH.Models.DataBase
{
    public partial class HotelContext : DbContext
    {
        public HotelContext()
        {
        }

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Allocation> Allocations { get; set; }
        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceList> ServiceLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.UserLogin)
                    .HasName("PK__Users__07557E5AAAB04136");

                entity.ToTable("Account");

                entity.Property(e => e.UserLogin)
                    .HasMaxLength(25)
                    .HasColumnName("User_login");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("User_password");

                entity.Property(e => e.UserRightsType)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("User_rightsType")
                    .HasDefaultValueSql("('User')");
            });

            modelBuilder.Entity<Allocation>(entity =>
            {
                entity.ToTable("Allocation");

                entity.Property(e => e.AllocationId)
                    .ValueGeneratedNever()
                    .HasColumnName("allocation_id");

                entity.Property(e => e.ApartmentsNumber).HasColumnName("apartments_number");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.FirstDate)
                    .HasColumnType("date")
                    .HasColumnName("first_date");


                entity.Property(e => e.LastDate)
                    .HasColumnType("date")
                    .HasColumnName("last_date");

                entity.HasOne(d => d.ApartmentsNumberNavigation)
                    .WithMany(p => p.Allocations)
                    .HasForeignKey(d => d.ApartmentsNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Allocatio__apart__4316F928");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Allocations)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Allocatio__clien__4222D4EF");
            });

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.HasKey(e => e.Number)
                    .HasName("PK__Apartmen__FD291E406965E19A");

                entity.Property(e => e.Number)
                    .ValueGeneratedNever()
                    .HasColumnName("number");

                entity.Property(e => e.ApartamentsLogin)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("Apartaments_login");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Floor).HasColumnName("floor");

                entity.Property(e => e.Price)
                    .HasColumnType("smallmoney")
                    .HasColumnName("price");

                entity.HasOne(d => d.ApartamentsLoginNavigation)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.ApartamentsLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Apartment__Apart__14270015");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .HasColumnName("gender")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Passport)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("passport");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(50)
                    .HasColumnName("patronymic");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("surname");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(13)
                    .HasColumnName("telephone");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("adress");

                entity.Property(e => e.EmployeeLogin)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("Employee_login");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(50)
                    .HasColumnName("patronymic");

                entity.Property(e => e.Post).HasColumnName("post");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("surname");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(13)
                    .HasColumnName("telephone");

                entity.HasOne(d => d.EmployeeLoginNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Employ__01142BA1");

                entity.HasOne(d => d.PostNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Post)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__post__3B75D760");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Salary)
                    .HasColumnType("smallmoney")
                    .HasColumnName("salary");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Post).HasColumnName("post");

                entity.Property(e => e.Price)
                    .HasColumnType("smallmoney")
                    .HasColumnName("price");

                entity.HasOne(d => d.PostNavigation)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.Post)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Service__post__2739D489");
            });

            modelBuilder.Entity<ServiceList>(entity =>
            {
                entity.ToTable("ServiceList");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.ServiceStatus)
                    .HasMaxLength(20)
                    .HasColumnName("service_status");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ServiceLists)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ServiceLi__clien__47DBAE45");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ServiceLists)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__ServiceLi__emplo__17F790F9");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceLists)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ServiceLi__servi__48CFD27E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
