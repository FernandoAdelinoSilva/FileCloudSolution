using FileCloudSolution.Models;

namespace FileCloudSolution.Interfaces;

public interface ISystemFiles
{
    void Add(string fileName, int size);
    bool Remove(string fileName);
    List<SystemFile> GetAll();
    SystemFile GetByName(string fileName);
}
