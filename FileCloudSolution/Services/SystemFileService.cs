using FileCloudSolution.DTOs;
using FileCloudSolution.Interfaces;
using FileCloudSolution.Models;

namespace FileCloudSolution.Services;

public class SystemFileService : ISystemFileService
{

    private readonly ISystemFiles _repository;

    public SystemFileService(ISystemFiles repository)
    {
        _repository = repository;
    }

    public void AddFile(string fileName, int size)
    {
        _repository.Add(fileName, size);
    }
    public SystemFileDTO AddFile(SystemFileDTO systemFile)
    {
        var file = _repository.GetByName(systemFile.Name);

        if (file != null)
            throw new InvalidOperationException("File Already Exists");

        _repository.Add(systemFile.Name, systemFile.Size);
        return systemFile;
    }

    public List<SystemFile> GetAllFiles()
    {
        return _repository.GetAll();
    }

    public SystemFile? GetFileByName(string fileName)
    {
        return _repository.GetByName(fileName);
    }
}
