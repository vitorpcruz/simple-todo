using Microsoft.EntityFrameworkCore;
using STD.Infra.Db;
using STD.Infra.Endpoints;
using STD.Infra.Maps;

#region Builder

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt =>
	opt.AddPolicy("AngularApp", policy =>
	{
		policy
			.WithOrigins("http://localhost:4200")
			.AllowAnyMethod()
			.AllowAnyHeader();
	}
));

builder.Services.AddDbContext<ApplicationContext>(opt =>
{
	opt.UseNpgsql(builder.Configuration.GetConnectionString("default"));
});

builder.Services.MapAllRepos();
builder.Services.MapAllUseCases();

#endregion Builder

#region App

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("AngularApp");
app.UseSwagger();
app.MapTodoEndpoints();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.Run();

#endregion App