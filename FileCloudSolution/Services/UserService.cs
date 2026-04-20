using FileCloudSolution.DTOs;
using FileCloudSolution.Interfaces;
using FileCloudSolution.Models;

namespace FileCloudSolution.Services;

public class UserService : IUserService
{

    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public List<User> GetAllUsers()
    {
        return _repository.GetAllUsers();
    }

    public UserDTO AddUser(UserDTO user)
    {
        _repository.AddUser(user.Name, user.Capacity);
        return user;
    }

    public bool RemoveUser(string name)
    {
        return _repository.RemoveUser(name);
    }
}
