using Microsoft.EntityFrameworkCore;
using TogrulAPI.Entities;

namespace TogrulAPI.DAL
{
    public class TogrulDB : DbContext
    {
        public  TogrulDB(DbContextOptions<TogrulDB> options) : base(options) { }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<BannedWord> BannedWords { get; set; }
        public DbSet<Game> Games { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(b =>
            {
                b.HasKey(x => x.Code);
                b.HasIndex(x => x.LanguageName)
                .IsUnique();
                b.Property(x => x.Code)
                .IsFixedLength(true)
                .HasMaxLength(2);
                b.Property(x => x.LanguageName)
                .IsRequired()
                .HasMaxLength(32);
                b.Property(x => x.Icon)
                .HasMaxLength(400);
                b.HasMany(x => x.Words)
               .WithOne(x => x.Language)
               .HasForeignKey(x => x.LanguageCode);
            });
            modelBuilder.Entity<Word>(b =>
            {                
                b.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(32);
                b.HasOne(x => x.Language)
                .WithMany(x => x.Words)
                .HasForeignKey(x => x.LanguageCode);
                b.HasMany(x=>x.BannedWords)
                .WithOne(x=>x.Word)
                .HasForeignKey(x=>x.WordId);               
            });            
            base.OnModelCreating(modelBuilder);
        }
    }
}
