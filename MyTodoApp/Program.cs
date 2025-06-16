using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MyTodoApp.Models.Entities;
using MyTodoApp.Repository;
using MyTodoApp.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// builder.Services.AddDbContext<TodoContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddCors(options =>
    options.AddPolicy("AllowSpecificOrigin",
        corsPolicyBuilder => corsPolicyBuilder.WithOrigins("http://localhost:5173") 
            .AllowAnyHeader()
            .AllowAnyMethod()));
// builder.Services.AddSingleton<ITodoService, TodoService>();
// builder.Services.AddTransient<ITodoService, TodoService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
// Other 'app' configuration above...

// Add this section to ensure the table exists on startup
using (var connection = new SqliteConnection(builder.Configuration.GetConnectionString("DefaultConnection")))
{
    var sql = @"
        CREATE TABLE IF NOT EXISTS Todos (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL,
            IsComplete BOOLEAN NOT NULL
        );";
    connection.Execute(sql);
}


app.Run();
app.Run();