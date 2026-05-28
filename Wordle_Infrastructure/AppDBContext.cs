using Microsoft.EntityFrameworkCore;
using Wordle_Domain.Entities;

namespace Wordle_Infrastructure;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
    }

    public DbSet<Game> Games { get; set; }
    public DbSet<Guess> Guesses { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Game>()
            .HasMany(g => g.Guesses)
            .WithOne(g => g.Game)
            .HasForeignKey(g => g.GameId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Game>()
            .HasOne(g => g.User)
            .WithMany(u => u.Games)
            .HasForeignKey(g => g.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Game>()
            .Property(g => g.TargetWord)
            .HasMaxLength(5)
            .IsRequired();

        modelBuilder.Entity<Guess>()
            .Property(g => g.Word)
            .HasMaxLength(5)
            .IsRequired();

        modelBuilder.Entity<Guess>()
            .Property(g => g.GuessResult)
            .IsRequired();

        modelBuilder.Entity<User>()
            .Property(u => u.Username)
            .HasMaxLength(50)
            .IsRequired();

        modelBuilder.Entity<User>()
            .Property(u => u.Password)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();
    }
}