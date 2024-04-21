using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.VisualBasic;

namespace STD.Domain.Entities;

public class Todo : Entity
{
	public string Title { get; private set; }
	public bool Finished { get; private set; }
	public DateTime? FinishedAt { get; private set; }

	protected Todo()
	{ }

	public static Todo NewTask(string title, bool finished = false)
	{
		var todo = new Todo
		{
			Title = title,
			Finished = finished,
			FinishedAt = DateTime.MinValue,
		};
		Validate(todo);
		return todo;
	}

	public static void Validate(Todo todoTask)
	{
		if (string.IsNullOrWhiteSpace(todoTask.Title))
			throw new Exception("Insira um título válido.");

		if (todoTask.Title.Length < 3 || todoTask.Title.Length > 60)
			throw new Exception("O título deve ter entre 3 a 60 caracteres.");
	}

	public void FinishTodo()
	{
		FinishedAt = DateTime.Now;
		Finished = true;
	}
}