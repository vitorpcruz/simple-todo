using Microsoft.AspNetCore.Mvc;
using STD.Domain.Entities;
using STD.Domain.Interfaces.Repositories;

namespace STD.UseCases.ListTodo;

public class ListTodoUseCase : IListTodoUseCase
{
	private readonly ITodoRepository _todoRepository;

	public ListTodoUseCase(ITodoRepository todoRepository)
	{
		_todoRepository = todoRepository;
	}

	public async Task<IEnumerable<RegisteredTodo>> Execute()
	{
		var todos = await _todoRepository.FindAll();

		var todosTransformed = todos.Select(x =>
			new RegisteredTodo(
				x.Id,
				x.Title,
				x.Finished,
				SetDateBlankIfMinDate(GetLastUpdate(x))
			)
		);

		return todosTransformed;
	}

	private static string SetDateBlankIfMinDate(DateTime dateTime)
		=> dateTime == DateTime.MinValue ? "-" : dateTime.ToString("g");

	private static DateTime GetLastUpdate(Todo todo)
		=> (todo.FinishedAt > todo.CreatedAt)
			? todo.FinishedAt.Value
			: todo.CreatedAt;
}