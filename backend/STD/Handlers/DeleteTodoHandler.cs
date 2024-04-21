using Microsoft.AspNetCore.Mvc;
using STD.UseCases.DeleteTodoUseCase;

namespace STD.Handlers;

public static class DeleteTodoHandler
{
	public static string Path = "/todos/{id:int}";
	public static Delegate Handler => Action;

	public static async Task<IResult> Action(
		[FromRoute] int id,
		[FromServices] ILogger<DeleteTodoUseCase> logger,
		[FromServices] IDeleteTodoUseCase useCase
	)
	{
		try
		{
			await useCase.Execute(id);
			return Results.NoContent();
		}
		catch (Exception ex)
		{
			logger.LogError(ex, $"Ocorreu um erro ao executar o useCase {nameof(IDeleteTodoUseCase)}.");
			return Results.Problem(
				statusCode: 500,
				detail: "Não foi cadastrar ao remover a tarefa selecionada. Contate o administrador."
			);
		}
	}
}