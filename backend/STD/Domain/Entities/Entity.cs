namespace STD.Domain.Entities;

public abstract class Entity
{
	public int Id { get; }
	public DateTime CreatedAt { get; }

	protected Entity()
	{
		CreatedAt = DateTime.Now;
	}
}