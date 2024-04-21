using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using STD.UseCases;
using STD.UseCases.DeleteTodoUseCase;
using STD.UseCases.UpdateTask;

namespace STD.Handlers;

public static class FinishTodoHandler
{
	public static string Path = "/todos/{id:int}";
	public static Delegate Handler => Action;

	public static async Task<IResult> Action(
		[FromRoute] int id,
		[FromServices] ILogger<FinishTodoUseCase> logger,
		[FromServices] IFinishTodoUseCase useCase
	)
	{
		try
		{
			await useCase.Execute(id);
			return Results.NoContent();
		}
		catch (Exception ex)
		{
			logger.LogError(ex, $"Ocorreu um erro ao executar o useCase {nameof(IFinishTodoUseCase)}.");
			return Results.Problem(
				statusCode: 500,
				detail: "Não foi possível finalizar a tarefa selecionada. Contate o administrador."
			);
		}
	}
}