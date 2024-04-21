using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STD.Domain.Entities;

namespace STD.Infra.EntitiesConfig;

public class TodoEntityTypeConfiguration : IEntityTypeConfiguration<Todo>
{
	public void Configure(EntityTypeBuilder<Todo> builder)
	{
		builder.HasKey(todo => todo.Id);

		builder.Property(todo => todo.Id).HasIdentityOptions();

		builder.Property(todo => todo.Title)
			.HasColumnType("varchar")
			.HasMaxLength(250)
			.IsRequired();

		builder.Property(todo => todo.Finished)
			.HasDefaultValue(false)
			.IsRequired();

		builder.Property(todo => todo.CreatedAt)
			.IsRequired();

		builder.Property(todo => todo.FinishedAt);

		builder.HasData(
			new
			{
				Id = 1,
				Title = "Comprar maçãs",
				Finished = true,
				CreatedAt = new DateTime(2024, 04, 01),
				ModifiedAt = DateTime.MinValue,
				FinishedAt = DateTime.MinValue,
			}
	);
	}
}