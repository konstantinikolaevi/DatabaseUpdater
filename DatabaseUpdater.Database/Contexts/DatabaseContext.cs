using DatabaseUpdater.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseUpdater.Database.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupUser> GroupUsers { get; set; }
    public DbSet<Role> Roles { get; set; }

    public DbSet<Location> Locations { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Supply> Supplies { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<SupplyMaterial> SupplyMaterials { get; set; }

    public DatabaseContext(string connectionString) => Database.SetConnectionString(connectionString);

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DatabaseContext()
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        optionsBuilder.UseNpgsql("Host=localhost;Port=5454;Database=DatabaseUpdater;Username=postgres;Password=1");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<User>().Property(x => x.Id).UseIdentityAlwaysColumn();
        modelBuilder.Entity<Group>().Property(x => x.Id).UseIdentityAlwaysColumn();
        modelBuilder.Entity<GroupUser>().Property(x => x.Id).UseIdentityAlwaysColumn();
        modelBuilder.Entity<Role>().Property(x => x.Id).UseIdentityAlwaysColumn();
        modelBuilder.Entity<Location>().Property(x => x.Id).UseIdentityAlwaysColumn();
        modelBuilder.Entity<Warehouse>().Property(x => x.Id).UseIdentityAlwaysColumn();
        modelBuilder.Entity<Supply>().Property(x => x.Id).UseIdentityAlwaysColumn();
        modelBuilder.Entity<Material>().Property(x => x.Id).UseIdentityAlwaysColumn();
        modelBuilder.Entity<SupplyMaterial>().Property(x => x.Id).UseIdentityAlwaysColumn();

        modelBuilder.Entity<User>().HasIndex(x => x.Login).IsUnique();
        modelBuilder.Entity<Group>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<Role>().HasIndex(x => new { x.Name, x.Code }).IsUnique();
        modelBuilder.Entity<Material>().HasIndex(x => x.Code).IsUnique();

        modelBuilder.Entity<Warehouse>().HasMany(x => x.OutgoingSupplies).WithOne(x => x.OutgoingPlace);
        modelBuilder.Entity<Warehouse>().HasMany(x => x.IncomingSupplies).WithOne(x => x.IncomingPlace);

        modelBuilder.Entity<User>().ToTable(x => x.HasCheckConstraint($@"Сheck_{nameof(Users)}_{nameof(User.PhoneNumber)}", @$"""{nameof(User.PhoneNumber)}"" ~ '^\d*$'"));
    }
}