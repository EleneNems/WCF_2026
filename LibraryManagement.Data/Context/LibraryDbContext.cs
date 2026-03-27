using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LibraryManagement.Data.Entities;

namespace LibraryManagement.Data.Context
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext() : base("name=LibraryDbConnection")
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<BorrowTransaction> BorrowTransactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Member>().ToTable("Members");
            modelBuilder.Entity<BorrowTransaction>().ToTable("BorrowTransactions");

            modelBuilder.Entity<BorrowTransaction>()
                .HasRequired(bt => bt.Book)
                .WithMany(b => b.BorrowTransactions)
                .HasForeignKey(bt => bt.BookId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BorrowTransaction>()
                .HasRequired(bt => bt.Member)
                .WithMany(m => m.BorrowTransactions)
                .HasForeignKey(bt => bt.MemberId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}