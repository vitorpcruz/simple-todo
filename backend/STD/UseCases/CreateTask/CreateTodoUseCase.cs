using STD.Domain.Entities;
using STD.Domain.Interfaces.Repositories;
using STD.Exceptions;

namespace STD.UseCases.CreateTask;

public class CreateTodoUseCase : ICreateTodoUseCase
{
	private readonly ITodoRepository _todoRepository;

	public CreateTodoUseCase(ITodoRepository todoRepository)
	{
		_todoRepository = todoRepository;
	}

	public async Task Execute(CreateTaskDTO createTodoDTO)
	{
		var registeredTodo = await _todoRepository.FindByTitle(createTodoDTO.Title);
		DomainException.ThrowsIf(registeredTodo is not null, "Já existe uma tarefa com este nome cadastrada.");

		var newTodo = Todo.NewTask(createTodoDTO.Title);
		await _todoRepository.Add(newTodo);
	}
}