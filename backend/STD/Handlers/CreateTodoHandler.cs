using Microsoft.AspNetCore.Mvc;
using STD.Exceptions;
using STD.UseCases;
using STD.UseCases.CreateTask;
using STD.UseCases.ListTodo;

namespace STD.Handlers;

public static class CreateTodoHandler
{
	public static string Path = "/todos";
	public static Delegate Handler => Action;

	public static async Task<IResult> Action([FromBody] CreateTaskDTO createTodoDTO,
											 [FromServices] ILogger<CreateTodoUseCase> logger,
											 [FromServices] ICreateTodoUseCase useCase)
	{
		try
		{
			await useCase.Execute(createTodoDTO);
			return Results.Created();
		}
		catch (DomainException dex)
		{
			return Results.Problem(
				statusCode: 400,
				detail: dex.Message
			);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, $"Ocorreu um erro ao executar o useCase {nameof(ICreateTodoUseCase)}.");
			return Results.Problem(
				statusCode: 500,
				detail: "Não foi cadastrar a nova tarefa. Contate o administrador."
			);
		}
	}
}