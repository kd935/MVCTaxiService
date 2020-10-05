using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace TaxiService.Models
{
    public partial class TaxiServiceContext : IdentityDbContext
    {
        public TaxiServiceContext()
        {
        }

        public TaxiServiceContext(DbContextOptions<TaxiServiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Drivers> Drivers { get; set; }
        public virtual DbSet<DriversAndTimes> DriversAndTimes { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Time> Time { get; set; }
        public virtual DbSet<Vehicles> Vehicles { get; set; }

        public int GetMySequence()
        {
            SqlParameter result = new SqlParameter("@result", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            Database.ExecuteSqlRaw(
                       "SELECT @result = (NEXT VALUE FOR IdGen)", result);

            return (int)result.Value;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=TaxiService;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.ClientPhoneNumber)
                    .HasName("PK__Clients__F48965FECB992C12");

                entity.Property(e => e.ClientPhoneNumber)
                    .HasColumnName("client_phone_number")
                    .HasMaxLength(12);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasColumnName("client_name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Drivers>(entity =>
            {
                entity.HasKey(e => e.DriverPhoneNumber)
                    .HasName("PK__Drivers__E882CAE8427952ED");

                entity.Property(e => e.DriverPhoneNumber)
                    .HasColumnName("driver_phone_number")
                    .HasMaxLength(12);

                entity.Property(e => e.DriverStatus)
                    .IsRequired()
                    .HasColumnName("driver_status")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('Свободен')");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Drivers)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_location_id");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Drivers)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vehicle_id");
            });

            modelBuilder.Entity<DriversAndTimes>(entity =>
            {
                entity.HasKey(e => new { e.TimeId, e.DriverPhoneNumber })
                    .HasName("PK__DriversA__913F471794A9766C");

                entity.Property(e => e.TimeId).HasColumnName("time_id");

                entity.Property(e => e.DriverPhoneNumber)
                    .HasColumnName("driver_phone_number")
                    .HasMaxLength(12);

                entity.HasOne(d => d.DriverPhoneNumberNavigation)
                    .WithMany(p => p.DriversAndTimes)
                    .HasForeignKey(d => d.DriverPhoneNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_driver_phone");

                entity.HasOne(d => d.Time)
                    .WithMany(p => p.DriversAndTimes)
                    .HasForeignKey(d => d.TimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_time_id");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationId)
                    .HasColumnName("location_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Location1)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ClientPhoneNumber)
                    .IsRequired()
                    .HasColumnName("client_phone_number")
                    .HasMaxLength(12);

                entity.Property(e => e.Comforts)
                    .HasColumnName("comforts")
                    .HasMaxLength(110);

                entity.Property(e => e.DriverPhoneNumber)
                    .IsRequired()
                    .HasColumnName("driver_phone_number")
                    .HasMaxLength(12);

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.MinimalPrice).HasColumnName("minimal_price");

                entity.Property(e => e.OrderStatus)
                    .IsRequired()
                    .HasColumnName("order_status")
                    .HasMaxLength(10);

                entity.Property(e => e.OrderTimeId).HasColumnName("order_time_id");

                entity.HasOne(d => d.ClientPhoneNumberNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.ClientPhoneNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_client");

                entity.HasOne(d => d.DriverPhoneNumberNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.DriverPhoneNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_driver");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_location_id");

                entity.HasOne(d => d.OrderTime)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.OrderTimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_time");
            });

            modelBuilder.Entity<Time>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Time1)
                    .HasColumnName("time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Vehicles>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.VehicleNumber)
                    .IsRequired()
                    .HasColumnName("vehicle_number")
                    .HasMaxLength(8);

                entity.Property(e => e.VehicleType)
                    .IsRequired()
                    .HasColumnName("vehicle_type")
                    .HasMaxLength(12);
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
