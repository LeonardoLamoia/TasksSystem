using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data;

public class TasksSystemDbContext : DbContext
{
    public TasksSystemDbContext(DbContextOptions<TasksSystemDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<UserModel> Users { get; set; }
    
    public DbSet<TaskModel> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}  