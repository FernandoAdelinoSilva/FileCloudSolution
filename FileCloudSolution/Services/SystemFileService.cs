using FileCloudSolution.Interfaces;
using FileCloudSolution.Models;
using FileCloudSolution.Repositories;

namespace FileCloudSolution.Services;

public class SystemFileService : ISystemFileService
{
    private readonly SystemFiles _repository;

    public SystemFileService(SystemFiles repository)
    {
        _repository = repository;
    }

    public void AddFile(string fileName, int size)
    {
        _repository.Add(fileName, size);
    }

    public List<SystemFile> GetAllFiles()
    {
        return _repository.GetAll();
    }
}
