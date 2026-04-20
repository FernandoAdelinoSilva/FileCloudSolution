using FileCloudSolution.Interfaces;
using FileCloudSolution.Models;

namespace FileCloudSolution.Repositories;

public class UserRepository : IUserRepository
{
    private List<User> _users { get; set; } = new List<User>();

    public bool AddUser(string name, int capacity)
    {
        var user = new User(name, capacity);
        _users.Add(user);

        return true;
    }

    public bool RemoveUser(string name)
    {
        var user = _users.FirstOrDefault(u => u.Name == name);
        if (user != null)
        {
            _users.Remove(user);
            return true;
        }
        return false;
    }
}
