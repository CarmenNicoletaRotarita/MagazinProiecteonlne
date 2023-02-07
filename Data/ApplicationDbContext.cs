using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MagazinProiecte.Models.DBObjects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MagazinProiecte.Data
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

      //  public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
       // public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
      //  public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
      //  public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
      //  public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
      //  public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Carti> Cartis { get; set; } = null!;
        public virtual DbSet<Clienti> Clientis { get; set; } = null!;
        public virtual DbSet<Comenzi> Comenzis { get; set; } = null!;
        public virtual DbSet<Editura> Edituras { get; set; } = null!;
        public virtual DbSet<Oferte> Ofertes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<AspNetRole>(entity =>
            //{
            //    entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedName] IS NOT NULL)");

            //    entity.Property(e => e.Name).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<AspNetRoleClaim>(entity =>
            //{
            //    entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetRoleClaims)
            //        .HasForeignKey(d => d.RoleId);
            //});

            //modelBuilder.Entity<AspNetUser>(entity =>
            //{
            //    entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            //    entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedUserName] IS NOT NULL)");

            //    entity.Property(e => e.Email).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

            //    entity.Property(e => e.UserName).HasMaxLength(256);

            //    entity.HasMany(d => d.Roles)
            //        .WithMany(p => p.Users)
            //        .UsingEntity<Dictionary<string, object>>(
            //            "AspNetUserRole",
            //            l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
            //            r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
            //            j =>
            //            {
            //                j.HasKey("UserId", "RoleId");

            //                j.ToTable("AspNetUserRoles");

            //                j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
            //            });
            //});

            //modelBuilder.Entity<AspNetUserClaim>(entity =>
            //{
            //    entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserClaims)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserLogin>(entity =>
            //{
            //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            //    entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            //    entity.Property(e => e.LoginProvider).HasMaxLength(128);

            //    entity.Property(e => e.ProviderKey).HasMaxLength(128);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserLogins)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserToken>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            //    entity.Property(e => e.LoginProvider).HasMaxLength(128);

            //    entity.Property(e => e.Name).HasMaxLength(128);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserTokens)
            //        .HasForeignKey(d => d.UserId);
            //});

            modelBuilder.Entity<Carti>(entity =>
            {
                entity.HasKey(e => e.Idcarte)
                    .HasName("PK__Carti__D9C17F2B80CC12AA");

                entity.ToTable("Carti");

                entity.Property(e => e.Idcarte)
                    .ValueGeneratedNever()
                    .HasColumnName("IDCarte");

                entity.Property(e => e.DataPublicare).HasColumnType("datetime");

                entity.Property(e => e.Descriere).IsUnicode(false);

                entity.Property(e => e.Titlu)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Clienti>(entity =>
            {
                entity.HasKey(e => e.Idclient)
                    .HasName("PK__Clienti__CDECAB2CBFB5F2D6");

                entity.ToTable("Clienti");

                entity.Property(e => e.Idclient)
                    .ValueGeneratedNever()
                    .HasColumnName("IDClient");

                entity.Property(e => e.Adresa)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gen)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nume)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Telefon)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comenzi>(entity =>
            {
                entity.HasKey(e => e.Idcomanda)
                    .HasName("PK__Comenzi__047930351759AAA9");

                entity.ToTable("Comenzi");

                entity.Property(e => e.Idcomanda)
                    .ValueGeneratedNever()
                    .HasColumnName("IDComanda");

                entity.Property(e => e.DataLivrare).HasColumnType("datetime");

                entity.Property(e => e.DataPlasare).HasColumnType("datetime");
            });

            modelBuilder.Entity<Editura>(entity =>
            {
                entity.HasKey(e => e.Ideditura)
                    .HasName("PK__Editura__2C3438C8135B971A");

                entity.ToTable("Editura");

                entity.Property(e => e.Ideditura)
                    .ValueGeneratedNever()
                    .HasColumnName("IDEditura");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NumeEditura)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Oferte>(entity =>
            {
                entity.HasKey(e => e.Idoferta)
                    .HasName("PK__Oferte__94F9F54720729B58");

                entity.ToTable("Oferte");

                entity.Property(e => e.Idoferta)
                    .ValueGeneratedNever()
                    .HasColumnName("IDOferta");

                entity.Property(e => e.DataEveniment).HasColumnType("datetime");

                entity.Property(e => e.DataLansare).HasColumnType("datetime");

                entity.Property(e => e.DataLichidare).HasColumnType("datetime");

                entity.Property(e => e.DenumireOferte)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Descriere)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Tags)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
