namespace STD.UseCases.UpdateTask;

public interface IFinishTodoUseCase
{
	Task Execute(int todoId);
}