namespace STD.UseCases.DeleteTodoUseCase;

public interface IDeleteTodoUseCase
{
	Task Execute(int todoId);
}