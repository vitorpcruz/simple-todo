using Microsoft.AspNetCore.Mvc;
using STD.UseCases;
using STD.UseCases.ListTodo;

namespace STD.Handlers;

public static class FindAllTodoHandler
{
	public static string Path = "/todos";
	public static Delegate Handler => Action;

	public static async Task<IResult> Action(
		[FromServices] ILogger<ListTodoUseCase> logger,
		[FromServices] IListTodoUseCase useCase)
	{
		try
		{
			var result = await useCase.Execute();
			return Results.Ok(result);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, $"Ocorreu um erro ao executar o useCase {nameof(IListTodoUseCase)}.");
			return Results.Problem(
				statusCode: 500,
				detail: "Não foi possível as tarefas já cadastradas. Contate o administrador."
			);
		}
	}
}