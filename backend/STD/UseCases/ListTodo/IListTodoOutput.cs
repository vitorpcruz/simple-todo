namespace STD.UseCases.ListTodo;

public interface IListTodoOutput
{
	void OK(IEnumerable<RegisteredTodo> todos);
}