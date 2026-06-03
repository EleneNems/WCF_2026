using Microsoft.EntityFrameworkCore;
using Wordle_Domain.Entities;

namespace Wordle_Infrastructure;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public DbSet<Game> Games { get; set; }
    public DbSet<Guess> Guesses { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Statistic> Statistics { get; set; }

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
            .OnDelete(DeleteBehavior.Cascade);

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
            .Property(u => u.Email)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<User>()
            .Property(u => u.PasswordHash)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Statistic>()
            .HasOne(s => s.User)
            .WithOne(u => u.Statistic)
            .HasForeignKey<Statistic>(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}