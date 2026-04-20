using FileCloudSolution.DTOs;
using FileCloudSolution.Models;

namespace FileCloudSolution.Interfaces;

public interface ISystemFileService
{
    void AddFile(string fileName, int size);
    SystemFileDTO AddFile(SystemFileDTO systemFile);
    SystemFile? GetFileByName(string fileName);
    SystemFile? GetLargestFile();
    List<SystemFile> GetAllFiles();
    bool Delete(string fileName);
}
