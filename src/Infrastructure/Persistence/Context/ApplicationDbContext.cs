using Finbuckle.MultiTenant;
using test.server.Application.Common.Events;
using test.server.Application.Common.Interfaces;
using test.server.Domain.Catalog;
using test.server.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using test.server.Domain.IZE;

namespace test.server.Infrastructure.Persistence.Context;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(ITenantInfo currentTenant, DbContextOptions options, ICurrentUser currentUser, ISerializerService serializer, IOptions<DatabaseSettings> dbSettings, IEventPublisher events)
        : base(currentTenant, options, currentUser, serializer, dbSettings, events)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<TypeChambre> TypeChambres => Set<TypeChambre>();
    public DbSet<Chambre> Chambres => Set<Chambre>();
    public DbSet<Agent> Agents => Set<Agent>();
    public DbSet<Client> Clients => Set<Client>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Brand>().ToTable("Brands", SchemaNames.Catalog);
        modelBuilder.Entity<Product>().ToTable("Products", SchemaNames.Catalog);
        modelBuilder.HasDefaultSchema(SchemaNames.IzeEntities);
    }
}