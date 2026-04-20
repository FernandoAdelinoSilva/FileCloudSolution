namespace FileCloudSolution.Interfaces;

public interface IUserService
{
    void AddUser(string username, int capacity);
    bool RemoveUser(string name);
}
