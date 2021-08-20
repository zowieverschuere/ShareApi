using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShareApi.Models;


namespace ShareApi.Data
{
    public class ShareContext : IdentityDbContext
    {
        public ShareContext(DbContextOptions<ShareContext> options) : base(options)
        {
        }


        public ShareContext() { }
        protected override void OnModelCreating(ModelBuilder builder)
        {


            base.OnModelCreating(builder);



           
            builder.Entity<Share>().HasKey(s => s.Id);

            builder.Entity<Share>().Property(r => r.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Share>().Property(r => r.StockName).IsRequired().HasMaxLength(4);
            builder.Entity<Share>().Property(r => r.BuyPrice).IsRequired();
            builder.Entity<Share>().Property(r => r.Discription).HasMaxLength(500);
            builder.Entity<Share>().HasOne(r => r.User).WithMany(r => r.Shares);

         
            builder.Entity<User>().HasKey(u => u.UserId);
            builder.Entity<User>().Property(u => u.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(u => u.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(100);

            builder.Entity<User>().HasMany(u => u.Shares).WithOne(u => u.User);
        
    }

        public DbSet<Share> Shares { get; set; }
        public DbSet<User> Customers { get; set; }
    }
}
