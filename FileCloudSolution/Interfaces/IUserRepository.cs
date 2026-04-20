namespace FileCloudSolution.Interfaces;

public interface IUserRepository
{
    bool AddUser(string name, int capacity);
    bool RemoveUser(string name);
}
