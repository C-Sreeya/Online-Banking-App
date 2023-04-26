using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DALayer.Models
{
    public partial class OnlineBankingSystemDbContext : DbContext
    {
        public OnlineBankingSystemDbContext()
        {
        }

        public OnlineBankingSystemDbContext(DbContextOptions<OnlineBankingSystemDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<UserCredential> UserCredentials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LIN80018294\\SQLEXPRESS; Database=OnlineBankingSystemDb; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountNo)
                    .HasName("PK__Accounts__B19EBB62F6D9E161");

                entity.Property(e => e.AccountNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Account_no");

                entity.Property(e => e.AccountTypeId).HasColumnName("Account_Type_id");

                entity.Property(e => e.Branch)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.Ifsc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IFSC");

                entity.Property(e => e.UserType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountTypeId)
                    .HasConstraintName("FK__Accounts__Accoun__4AB81AF0");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Accounts__Custom__49C3F6B7");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.ToTable("AccountType");

                entity.Property(e => e.AccountTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("Account_Type_id");

                entity.Property(e => e.AcctType)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Acct_Type");

                entity.Property(e => e.MinBalance).HasColumnName("Min_Balance");

                entity.Property(e => e.TransactionLimit).HasColumnName("Transaction_limit");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("Customer_ID");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Address");

                entity.Property(e => e.CustomerAge).HasColumnName("Customer_Age");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Name");

                entity.Property(e => e.CustomerPhNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Ph_No");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.Property(e => e.LoanId).HasColumnName("Loan_Id");

                entity.Property(e => e.AccountNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Account_no");

                entity.Property(e => e.ApprovalStatus)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Approval_Status");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.LoanDate)
                    .HasColumnType("date")
                    .HasColumnName("Loan_Date");

                entity.Property(e => e.LoanStatus)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Loan_Status");

                entity.HasOne(d => d.AccountNoNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.AccountNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Loans__Account_n__03F0984C");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Loans__Customer___02FC7413");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.TransactionId).HasColumnName("Transaction_id");

                entity.Property(e => e.AccountNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Account_no");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_id");

                entity.Property(e => e.DateOfTransaction)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_of_Transaction");

                entity.Property(e => e.DebitOrCredit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReceiverAccountNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Receiver_AccountNo");

                entity.Property(e => e.ReceiverUserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Transaction_Status");

                entity.HasOne(d => d.AccountNoNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AccountNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Accou__17036CC0");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Custo__160F4887");
            });

            modelBuilder.Entity<UserCredential>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__UserCred__C9F284570974572A");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserRole)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
