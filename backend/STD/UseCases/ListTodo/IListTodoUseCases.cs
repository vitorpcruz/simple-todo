namespace STD.UseCases.ListTodo;

public interface IListTodoUseCase
{
	Task<IEnumerable<RegisteredTodo>> Execute();
}