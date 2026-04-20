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

    public bool AddFileToUser(string userName, SystemFileDTO file)
    {
        var user = _repository.GetAllUsers().FirstOrDefault(u => u.Name == userName);
        if (user == null) return false;
        
        var storageSize = user.CloudStorage.GetAllFiles().Sum(f => f.Size);

        if ((storageSize + file.Size) > user.Capacity)
            throw new InvalidOperationException("Capacity exceeded, please delete a file to continue");

        user.CloudStorage.AddFile(file.Name, file.Size);
        return true;
    }
}
