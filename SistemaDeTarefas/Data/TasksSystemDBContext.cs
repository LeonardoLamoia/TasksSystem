using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data.Map;
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
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new TaskMap());
        
        base.OnModelCreating(modelBuilder);
    }
}  