using STD.Domain.Interfaces.Repositories;

namespace STD.UseCases.DeleteTodoUseCase;

public class DeleteTodoUseCase : IDeleteTodoUseCase
{
	private readonly ITodoRepository _todoRepository;

	public DeleteTodoUseCase(ITodoRepository todoRepository)
	{
		_todoRepository = todoRepository;
	}

	public async Task Execute(int todoId)
	{
		var todo = await _todoRepository.FindById(todoId);

		if (todo is not null) _todoRepository.Delete(todo);
	}
}