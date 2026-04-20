using FileCloudSolution.Models;

namespace FileCloudSolution.Interfaces;

public interface ICloudStorage
{
    void AddFile(string fileName, int size);
    bool RemoveFile(string fileName);
    List<SystemFile> GetAllFiles();
    SystemFile GetFileByName(string fileName);
    SystemFile GetLargestFile();
}
