using STD.UseCases.CreateTask;
using STD.UseCases.DeleteTodoUseCase;
using STD.UseCases.ListTodo;
using STD.UseCases.UpdateTask;

namespace STD.Infra.Maps;

public static class UseCasesMapper
{
	public static void MapAllUseCases(this IServiceCollection services)
	{
		services.AddScoped<IListTodoUseCase, ListTodoUseCase>();
		services.AddScoped<ICreateTodoUseCase, CreateTodoUseCase>();
		services.AddScoped<IFinishTodoUseCase, FinishTodoUseCase>();
		services.AddScoped<IDeleteTodoUseCase, DeleteTodoUseCase>();
	}
}