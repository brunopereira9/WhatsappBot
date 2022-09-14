using Microsoft.EntityFrameworkCore;
using WhatsappBot.Entities;

namespace WhatsappBot.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<Contact> Contacts { get; set; } = null ! ;
        public DbSet<Message> Messages { get; set; } = null ! ;
        public DbSet<People> Peoples { get; set; } = null ! ;
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();
        
            options.UseMySql(
                config.GetConnectionString("DatabaseLocal"),
                ServerVersion.AutoDetect(config.GetConnectionString("DatabaseLocal"))
            );
        }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     builder.Entity<Product>(buildAction => {
        //         buildAction
        //         .HasMany(product => product.StockConferences)
        //         .WithOne()
        //         .HasForeignKey(stockConference => stockConference.ProductId)
        //         .OnDelete(DeleteBehavior.Restrict);
        //     });
        // }


    }
}