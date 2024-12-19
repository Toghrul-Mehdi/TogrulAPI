using Microsoft.EntityFrameworkCore;
using TogrulAPI.Entities;

namespace TogrulAPI.DAL
{
    public class TogrulDB : DbContext
    {
        public  TogrulDB(DbContextOptions<TogrulDB> options) : base(options) { }
        public DbSet<Language> Languages { get; set; }
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
                b.HasData(new Language
                {
                    Code="az",
                    LanguageName="Azərbaycan",
                    Icon= "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Flag_of_Azerbaijan.svg/1200px-Flag_of_Azerbaijan.svg.png"
                });
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
