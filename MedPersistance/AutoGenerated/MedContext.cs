using System;
using System.Collections.Generic;
using MedDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MedPersistance
{
    public partial class MedContext : DbContext
    {
        public MedContext()
        {
        }

        public MedContext(DbContextOptions<MedContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Gender> Genders { get; set; } = null!;
        public virtual DbSet<Language> Languages { get; set; } = null!;
        public virtual DbSet<Oblast> Oblasts { get; set; } = null!;
        public virtual DbSet<Organization> Organizations { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Roletype> Roletypes { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<UserModule> UserModules { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost;Database=Med;Username=postgres;Password=postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Oblast>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Oblast)
                    .WithMany(p => p.Organizations)
                    .HasForeignKey(d => d.OblastId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("organization_oblast_id_fkey");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Organizations)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("organization_region_id_fkey");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Oblast)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.OblastId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("region_oblast_id_fkey");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Roletype)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.RoletypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("role_roletype_id_fkey");
            });

            modelBuilder.Entity<Roletype>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<UserModule>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.UserModules)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_module_gender_id_fkey");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.UserModules)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_module_language_id_fkey");

                entity.HasOne(d => d.Oblast)
                    .WithMany(p => p.UserModules)
                    .HasForeignKey(d => d.OblastId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_module_oblast_id_fkey");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.UserModules)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_module_organization_id_fkey");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.UserModules)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_module_region_id_fkey");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserModules)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_module_role_id_fkey");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.UserModules)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_module_status_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
