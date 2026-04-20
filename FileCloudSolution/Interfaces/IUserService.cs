using FileCloudSolution.DTOs;
using FileCloudSolution.Models;

namespace FileCloudSolution.Interfaces;

public interface IUserService
{
    List<User> GetAllUsers();
    UserDTO AddUser(UserDTO user);
    bool RemoveUser(string name);
    bool AddFileToUser(string userName, SystemFileDTO file);
}
