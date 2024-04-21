namespace STD.Domain.Entities;

public interface ITodo
{
	int Id { get; }
	string Title { get; }
	bool Finished { get; }
	DateTime CreatedAt { get; }
	DateTime? FinishedAt { get; }
}