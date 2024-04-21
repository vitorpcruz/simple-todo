using Microsoft.AspNetCore.Mvc;
using STD.Handlers;
using System.Net;

namespace STD.Infra.Endpoints;

public static class TodoEndpoints
{
	public static void MapTodoEndpoints(this IEndpointRouteBuilder app)
	{
		app.MapPost(CreateTodoHandler.Path, CreateTodoHandler.Handler);
		app.MapPut(FinishTodoHandler.Path, FinishTodoHandler.Handler);
		app.MapDelete(DeleteTodoHandler.Path, DeleteTodoHandler.Handler);
		app.MapGet(FindAllTodoHandler.Path, FindAllTodoHandler.Handler);
	}
}