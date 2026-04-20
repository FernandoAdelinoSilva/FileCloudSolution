using FileCloudSolution.Models;

namespace FileCloudSolution.Interfaces;

public interface ISystemFileService
{
    void AddFile(string fileName, int size);
    List<SystemFile> GetAllFiles();
}
