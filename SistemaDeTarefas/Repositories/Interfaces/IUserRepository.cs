using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repository.Interfaces;

public interface IUserRepository
{
    Task<List<UserModel>> FetchAllUsers();
    
    Task<UserModel> SearchById(int id);

    Task<UserModel> Add(UserModel user);

    Task<UserModel> Update(UserModel user, int id);

    Task<bool> Delete(int id);
}

