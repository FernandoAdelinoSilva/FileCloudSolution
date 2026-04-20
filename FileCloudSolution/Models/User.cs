using FileCloudSolution.Repositories;

namespace FileCloudSolution.Models;

public class User
{
    public string? Name { get; set; }
    public int Capacity { get; set; }
    public CloudStorageRepository CloudStorage { get; set; }

    public User(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
        CloudStorage = new CloudStorageRepository();
    }
}
