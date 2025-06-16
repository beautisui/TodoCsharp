using Dapper;
using Microsoft.Data.Sqlite;
using MyTodoApp.Models.Entities;
using System.Data;

namespace MyTodoApp.Repository
{
    public class TodoRepository(IConfiguration configuration) : ITodoRepository
    {
        private IDbConnection CreateConnection()
        {
            return new SqliteConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<Todo> CreateTodoFromDb(Todo todo)
        {
            var sql = "INSERT INTO Todos (Title, IsCompleted) VALUES (@Title, @IsCompleted)";
            using var connection = CreateConnection();
            await connection.ExecuteAsync(sql, todo);
            return todo;
        }

        public async Task<bool> DeleteTodo(int id)
        {
            var sql = "DELETE FROM Todos WHERE Id = @id";
            using var connection = CreateConnection();
            var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });
            return affectedRows > 0;
        }

        public async Task<IEnumerable<Todo>> GetAllTodo()
        {
            var sql = "SELECT * FROM Todos";
            using var connection = CreateConnection();
            return await connection.QueryAsync<Todo>(sql);
        }

        public async Task<Todo?> GetTodoByIdFromDb(int id)
        {
            var sql = "SELECT * FROM Todos WHERE Id = @Id";
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Todo>(sql, new { Id = id });
        }

        public async Task<bool> UpdateTodo(Todo updatedTodo)
        {
            var sql = @"UPDATE Todos 
                        SET Title = @Title, 
                            IsCompleted = @IsCompleted 
                      WHERE Id = @Id";

            using var connection = CreateConnection();
            var affectedRows = await connection.ExecuteAsync(sql, updatedTodo);
            return affectedRows > 0;
        }
    }
}