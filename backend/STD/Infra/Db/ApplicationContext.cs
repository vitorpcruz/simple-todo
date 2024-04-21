using Microsoft.EntityFrameworkCore;
using STD.Domain.Entities;
using STD.Infra.EntitiesConfig;

namespace STD.Infra.Db;

public class ApplicationContext : DbContext
{
	public DbSet<Todo> Todo { get; set; }

	public ApplicationContext(DbContextOptions<ApplicationContext> options)
		: base(options)
	{
		//fix Postgres timestamp without time zone
		AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoEntityTypeConfiguration).Assembly);
	}
}