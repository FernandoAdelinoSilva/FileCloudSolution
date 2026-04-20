using FileCloudSolution.Interfaces;

namespace FileCloudSolution.Services;

public class UserService : IUserService
{

    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public void AddUser(string username, int capacity)
    {
        _repository.AddUser(username, capacity);
    }

    public bool RemoveUser(string name)
    {
        return _repository.RemoveUser(name);
    }
}
