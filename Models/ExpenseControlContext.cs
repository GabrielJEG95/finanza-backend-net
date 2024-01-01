using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace finanza_backend_net.Models;

public partial class ExpenseControlContext : DbContext
{
    public ExpenseControlContext()
    {
    }

    public ExpenseControlContext(DbContextOptions<ExpenseControlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountMode> AccountModes { get; set; }

    public virtual DbSet<AccountType> AccountTypes { get; set; }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<CountryCurrency> CountryCurrencies { get; set; }

    public virtual DbSet<Money> Money { get; set; }

    public virtual DbSet<Movement> Movements { get; set; }

    public virtual DbSet<TypeMovement> TypeMovements { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserInformation> UserInformations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-UVK5HPI;Database=expense_control;Integrated Security=true; trusted_Connection= true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.IdAccount).HasName("PK__Account__B7B00CE3CB044CF6");

            entity.ToTable("Account");

            entity.Property(e => e.Account1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Account");
            entity.Property(e => e.Balance).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.HasOne(d => d.IdBankNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.IdBank)
                .HasConstraintName("FK__Account__IdBank__5BE2A6F2");

            entity.HasOne(d => d.IdMoneyNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.IdMoney)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Account__IdMoney__5AEE82B9");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Account__IdUser__59FA5E80");
        });

        modelBuilder.Entity<AccountMode>(entity =>
        {
            entity.HasKey(e => e.IdAccountMode).HasName("PK__AccountM__AF7711BDA614AE49");

            entity.ToTable("AccountMode");

            entity.Property(e => e.AccountMode1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AccountMode");
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<AccountType>(entity =>
        {
            entity.HasKey(e => e.IdAccountType).HasName("PK__AccountT__E5856E18648B960C");

            entity.ToTable("AccountType");

            entity.Property(e => e.AccountType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AccountType");
            entity.Property(e => e.Icon).HasColumnType("text");
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Bank>(entity =>
        {
            entity.HasKey(e => e.IdBank).HasName("PK__Bank__3EA5E684A9CB7831");

            entity.ToTable("Bank");

            entity.Property(e => e.Bank1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Bank");
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Banks)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("FK__Bank__IdCountry__4D94879B");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.IdCountry).HasName("PK__Country__F99F104D33ED3120");

            entity.ToTable("Country");

            entity.Property(e => e.Country1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Country");
            entity.Property(e => e.Icon).HasColumnType("text");
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<CountryCurrency>(entity =>
        {
            entity.HasKey(e => e.IdCountryCurrency).HasName("PK__CountryC__65951A6086409F8D");

            entity.ToTable("CountryCurrency");

            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.CountryCurrencies)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("FK__CountryCu__IdCou__47DBAE45");

            entity.HasOne(d => d.IdMoneyNavigation).WithMany(p => p.CountryCurrencies)
                .HasForeignKey(d => d.IdMoney)
                .HasConstraintName("FK__CountryCu__IdMon__48CFD27E");
        });

        modelBuilder.Entity<Money>(entity =>
        {
            entity.HasKey(e => e.IdMoney).HasName("PK__money__C27CFAD69FA6FB28");

            entity.ToTable("money");

            entity.Property(e => e.Money1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Money");
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            entity.Property(e => e.Symbol)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Movement>(entity =>
        {
            entity.HasKey(e => e.IdMovements).HasName("PK__Movement__5A5C898E2F09727B");

            entity.Property(e => e.MovementDate).HasColumnType("datetime");
            entity.Property(e => e.Movements).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<TypeMovement>(entity =>
        {
            entity.HasKey(e => e.IdTypeMovements).HasName("PK__TypeMove__3A3C167E249C6457");

            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.TypeMovements)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__users__B7C926389F9CE1D8");

            entity.ToTable("users");

            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.UserName)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserInformation>(entity =>
        {
            entity.HasKey(e => e.IdUserInfo).HasName("PK__UserInfo__CD7085C1858D0F73");

            entity.ToTable("UserInformation");

            entity.Property(e => e.BirthDays).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserInformations)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserInfor__IdUse__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
