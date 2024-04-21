namespace STD.UseCases.CreateTask;

public interface ICreateTodoUseCase
{
	Task Execute(CreateTaskDTO createTodoDTO);
}
