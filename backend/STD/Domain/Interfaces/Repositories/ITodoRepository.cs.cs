using STD.Domain.Entities;

namespace STD.Domain.Interfaces.Repositories;

public interface ITodoRepository
{
	Task<Todo?> FindById(int id);

	Task<IEnumerable<Todo>> FindAll();

	Task<Todo?> FindByTitle(string title);

	Task Add(Todo todo);

	void Update(Todo todo);

	void Delete(Todo todo);
}