using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using STD.Domain.Entities;
using STD.Domain.Interfaces.Repositories;
using STD.Infra.Db;

namespace STD.Infra.Repositories;

public class TodoRepository : ITodoRepository
{
	private readonly ApplicationContext _context;
	private readonly DbSet<Todo> _db;

	public TodoRepository(ApplicationContext context)
	{
		_context = context;
		_db = context.Set<Todo>();
	}

	public async Task<IEnumerable<Todo>> FindAll()
		=> await _db.AsNoTracking().OrderByDescending(x => x.Id).ToListAsync();

	public async Task<Todo?> FindById(int id)
		=> await _db.AsNoTracking().FirstOrDefaultAsync(todo => todo.Id == id);

	public async Task<Todo?> FindByTitle(string title)
		=> await _db.AsNoTracking().FirstOrDefaultAsync(todo => EF.Functions.Like(todo.Title, title));

	public async Task Add(Todo todo)
	{
		await _db.AddAsync(todo);
		await _context.SaveChangesAsync();
	}

	public void Update(Todo todo)
	{
		_db.Update(todo);
		_context.SaveChanges();
	}

	public void Delete(Todo todo)
	{
		_db.Remove(todo);
		_context.SaveChanges();
	}
}