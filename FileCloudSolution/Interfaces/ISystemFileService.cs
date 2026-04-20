using FileCloudSolution.DTOs;
using FileCloudSolution.Models;

namespace FileCloudSolution.Interfaces;

public interface ISystemFileService
{
    void AddFile(string fileName, int size);
    SystemFileDTO AddFile(SystemFileDTO systemFile);
    List<SystemFile> GetAllFiles();
}
