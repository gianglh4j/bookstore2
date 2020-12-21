using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public partial class BookStoredbContext : DbContext
    {
        public BookStoredbContext()
        {
        }

        public BookStoredbContext(DbContextOptions<BookStoredbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookBookType> BookBookType { get; set; }
        public virtual DbSet<BookType> BookType { get; set; }
        public virtual DbSet<OrderB> OrderB { get; set; }
        public virtual DbSet<OrderBDetail> OrderBDetail { get; set; }
       // public object BookBookTypes { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //                optionsBuilder.UseSqlServer("Server=DESKTOP-9EB2VUJ;Database=BookStore;Trusted_Connection=True;");
            //            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookImage)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<BookBookType>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.BookTypeId });

                entity.ToTable("Book_BookType");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookBookType)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Book_Book__BookI__2F10007B");

                entity.HasOne(d => d.BookType)
                    .WithMany(p => p.BookBookType)
                    .HasForeignKey(d => d.BookTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Book_Book__BookT__300424B4");
            });

            modelBuilder.Entity<BookType>(entity =>
            {
                entity.Property(e => e.BookTypeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderB>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__OrderB__C3905BCF8C9E9218");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderStatus)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderBDetail>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.OrderId });

                entity.ToTable("OrderB_Detail");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.OrderBDetail)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderB_De__BookI__32E0915F");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderBDetail)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderB_De__Order__33D4B598");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
