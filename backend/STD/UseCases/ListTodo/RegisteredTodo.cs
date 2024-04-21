namespace STD.UseCases.ListTodo;

public record RegisteredTodo(int Id,
							 string Title,
							 bool Finished,
							 string LastUpdatedAt);