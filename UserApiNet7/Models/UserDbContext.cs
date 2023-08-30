//using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace UserApiNet7.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;

        //cofig to support sql server
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=userdb;Trusted_Connection=true;TrustServerCertificate=true;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithOne()
                .HasForeignKey<User>(p => p.UserId);

            base.OnModelCreating(modelBuilder);
        }

        //Conversion logic if using sql db instead of in memory (DateOnly isn't supported yet)
        //protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        //{
        //    builder.Properties<DateOnly>()
        //        .HaveConversion<DateOnlyConverter>()
        //        .HaveColumnType("date");
        //}
    }

    //Conversion logic if using sql db instead of in memory (DateOnly isn't supported yet)
    //public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    //{
    //    public DateOnlyConverter() : base(
    //            d => d.ToDateTime(TimeOnly.MinValue),
    //            d => DateOnly.FromDateTime(d))
    //    { }
    //}
}

