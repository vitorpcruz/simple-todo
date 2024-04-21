using STD.Domain.Interfaces.Repositories;

namespace STD.UseCases.UpdateTask;

public class FinishTodoUseCase : IFinishTodoUseCase
{
	private readonly ITodoRepository _todoRepository;

	public FinishTodoUseCase(ITodoRepository todoRepository)
	{
		_todoRepository = todoRepository;
	}

	public async Task Execute(int id)
	{
		var todo = await _todoRepository.FindById(id);
		if (todo is null) return;

		todo.FinishTodo();
		_todoRepository.Update(todo);
	}
}