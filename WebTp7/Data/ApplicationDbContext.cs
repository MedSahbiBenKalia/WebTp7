using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebTp7.Models;
    
namespace WebTp7.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<FeedBack> FeedBacks { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Genre)
            .WithMany(g => g.Movies)
            .HasForeignKey(m => m.GenreId);

        modelBuilder.Entity<Movie>()
            .HasMany(m => m.FavoriteByUsers)
            .WithMany(u => u.FavoriteMovies)
            .UsingEntity(j => j.ToTable("UserMovies"));
        
        modelBuilder.Entity<FeedBack>()
            .HasOne(f => f.User)
            .WithMany(u => u.FeedBacks)
            .HasForeignKey(f => f.UserId);
        
        modelBuilder.Entity<FeedBack>()
            .HasOne(f => f.Movie)
            .WithMany(m => m.FeedBacks)
            .HasForeignKey(f => f.MovieId);
        modelBuilder.Entity<FeedBack>(entity =>
        {
            entity.Property(e => e.Rating)
                .HasPrecision(2, 1); // Specify precision and scale
        });
        
        base.OnModelCreating(modelBuilder);
    }
    
}