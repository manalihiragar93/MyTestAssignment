using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Multimedia> Multimedia { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(a => a.ArticleId);
                entity.Property(a => a.Title).HasMaxLength(500);
                entity.Property(a => a.Abstract).HasColumnType("nvarchar(max)");
                entity.Property(a => a.Url).HasColumnType("nvarchar(max)");
                entity.Property(a => a.Uri).HasColumnType("nvarchar(max)");
                entity.Property(a => a.Byline).HasMaxLength(255);
                entity.Property(a => a.Item_Type).HasMaxLength(100);
                entity.Property(a => a.Updated_Date).HasColumnType("datetime");
                entity.Property(a => a.Created_Date).HasColumnType("datetime");
                entity.Property(a => a.Published_Date).HasColumnType("datetime");
                entity.Property(a => a.Material_Type_Facet).HasMaxLength(255);
                entity.Property(a => a.Kicker).HasMaxLength(255);
                entity.Property(a => a.Short_Url).HasColumnType("nvarchar(max)");
            });

            modelBuilder.Entity<Multimedia>(entity =>
            {
                entity.HasKey(m => m.MultimediaId);
                entity.Property(m => m.Url).HasColumnType("nvarchar(max)");
                entity.HasOne<Article>()
                      .WithMany(a => a.Multimedia)
                      .HasForeignKey("ArticleId")
                      .OnDelete(DeleteBehavior.Cascade);
            });

        }

    }
}
