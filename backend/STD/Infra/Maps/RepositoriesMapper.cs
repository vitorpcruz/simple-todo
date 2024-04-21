using STD.Domain.Interfaces.Repositories;
using STD.Infra.Repositories;

namespace STD.Infra.Maps;

public static class RepositoriesMapper
{
	public static void MapAllRepos(this IServiceCollection services)
	{
		services.AddScoped<ITodoRepository, TodoRepository>();
	}
}