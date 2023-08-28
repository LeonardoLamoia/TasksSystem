using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repository.Interfaces;

namespace SistemaDeTarefas.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TasksSystemDbContext _dbContext;
    
    public UserRepository(TasksSystemDbContext tasksSystemDbContext)
    {
        _dbContext = tasksSystemDbContext;
    }

    public async Task<UserModel> SearchById(int id)
    {
        return  await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<List<UserModel>> FetchAllUsers()
    {
        return  await _dbContext.Users.ToListAsync();
    }

    public async Task<UserModel> Add(UserModel user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<UserModel> Update(UserModel user, int id)
    {
       UserModel userById = await SearchById(id);

       if (userById == null)
       {
           throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
       }

       userById.Name = user.Name;
       userById.Email = user.Email;
       
       _dbContext.Users.Update(userById);
       await _dbContext.SaveChangesAsync();

       return userById;
    }

    public async Task<bool> Delete(int id)
    {
        UserModel userById = await SearchById(id);

        if (userById == null)
        {
            throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
        }

        _dbContext.Users.Remove(userById);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}