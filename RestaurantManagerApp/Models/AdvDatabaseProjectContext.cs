using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestaurantManagerApp.Models
{
    public partial class AdvDatabaseProjectContext : DbContext
    {
        public AdvDatabaseProjectContext()
        {
        }

        public AdvDatabaseProjectContext(DbContextOptions<AdvDatabaseProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<EmployeeInfo> EmployeeInfo { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<RecipeLines> RecipeLines { get; set; }
        public virtual DbSet<ReservationItems> ReservationItems { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:advdatabaseclass.database.windows.net,1433;Initial Catalog=AdvDatabaseProject;Persist Security Info=False;User ID=databaseadmin;Password=Spring@2019;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CNum);

                entity.ToTable("CUSTOMERS");

                entity.HasIndex(e => e.CEmail)
                    .HasName("C_EMAIL_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CNum).HasColumnName("C_NUM");

                entity.Property(e => e.CAddy)
                    .IsRequired()
                    .HasColumnName("C_ADDY")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CCcnum).HasColumnName("C_CCNUM");

                entity.Property(e => e.CEmail)
                    .IsRequired()
                    .HasColumnName("C_EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CFname)
                    .IsRequired()
                    .HasColumnName("C_FNAME")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CLname)
                    .IsRequired()
                    .HasColumnName("C_LNAME")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeInfo>(entity =>
            {
                entity.HasKey(e => e.ENum);

                entity.ToTable("EMPLOYEE_INFO");

                entity.Property(e => e.ENum).HasColumnName("E_NUM");

                entity.Property(e => e.ELevel).HasColumnName("E_LEVEL");

                entity.Property(e => e.EName)
                    .IsRequired()
                    .HasColumnName("E_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.InvNum);

                entity.ToTable("INVENTORY");

                entity.Property(e => e.InvNum).HasColumnName("INV_NUM");

                entity.Property(e => e.InvDesc)
                    .IsRequired()
                    .HasColumnName("INV_DESC")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.InvPar).HasColumnName("INV_PAR");

                entity.Property(e => e.InvQoh).HasColumnName("INV_QOH");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemNum);

                entity.ToTable("ITEMS");

                entity.Property(e => e.ItemNum).HasColumnName("ITEM_NUM");

                entity.Property(e => e.ItemDesc)
                    .HasColumnName("ITEM_DESC")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("ITEM_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ItemPrice)
                    .HasColumnName("ITEM_PRICE")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.ONum);

                entity.ToTable("ORDERS");

                entity.Property(e => e.ONum).HasColumnName("O_NUM");

                entity.Property(e => e.OInvNum).HasColumnName("O_INV_NUM");

                entity.Property(e => e.OQuant).HasColumnName("O_QUANT");

                entity.HasOne(d => d.OInvNumNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OInvNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_O_INV_NUM");
            });

            modelBuilder.Entity<RecipeLines>(entity =>
            {
                entity.HasKey(e => e.RlNum);

                entity.ToTable("RECIPE_LINES");

                entity.Property(e => e.RlNum).HasColumnName("RL_NUM");

                entity.Property(e => e.RlInvNum).HasColumnName("RL_INV_NUM");

                entity.Property(e => e.RlItemNum).HasColumnName("RL_ITEM_NUM");

                entity.Property(e => e.RlQty).HasColumnName("RL_QTY");

                entity.HasOne(d => d.RlInvNumNavigation)
                    .WithMany(p => p.RecipeLines)
                    .HasForeignKey(d => d.RlInvNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RL_INV");

                entity.HasOne(d => d.RlItemNumNavigation)
                    .WithMany(p => p.RecipeLines)
                    .HasForeignKey(d => d.RlItemNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RL_ITEM");
            });

            modelBuilder.Entity<ReservationItems>(entity =>
            {
                entity.HasKey(e => e.RiNum);

                entity.ToTable("RESERVATION_ITEMS");

                entity.Property(e => e.RiNum).HasColumnName("RI_NUM");

                entity.Property(e => e.RiItemNum).HasColumnName("RI_ITEM_NUM");

                entity.Property(e => e.RiResNum).HasColumnName("RI_RES_NUM");

                entity.Property(e => e.RiStatus)
                    .HasColumnName("RI_STATUS")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.RiItemNumNavigation)
                    .WithMany(p => p.ReservationItems)
                    .HasForeignKey(d => d.RiItemNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RI_ITEM");

                entity.HasOne(d => d.RiResNumNavigation)
                    .WithMany(p => p.ReservationItems)
                    .HasForeignKey(d => d.RiResNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RI_REV");

                entity.HasOne(d => d.RiStatusNavigation)
                    .WithMany(p => p.ReservationItems)
                    .HasForeignKey(d => d.RiStatus)
                    .HasConstraintName("FK_EMP");
            });

            modelBuilder.Entity<Reservations>(entity =>
            {
                entity.HasKey(e => e.RNum);

                entity.ToTable("RESERVATIONS");

                entity.Property(e => e.RNum).HasColumnName("R_NUM");

                entity.Property(e => e.RCnum).HasColumnName("R_CNUM");

                entity.Property(e => e.RDate)
                    .HasColumnName("R_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.RPaid)
                    .HasColumnName("R_PAID")
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.RSubtotal)
                    .HasColumnName("R_SUBTOTAL")
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.RTable)
                    .HasColumnName("R_TABLE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RTime)
                    .HasColumnName("R_TIME")
                    .HasColumnType("time(6)");

                entity.HasOne(d => d.RCnumNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.RCnum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REF_CUS");
            });
        }
    }
}
