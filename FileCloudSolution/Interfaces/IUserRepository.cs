using FileCloudSolution.Models;

namespace FileCloudSolution.Interfaces;

public interface IUserRepository
{
    List<User> GetAllUsers();
    bool AddUser(string name, int capacity);
    bool RemoveUser(string name);
}
