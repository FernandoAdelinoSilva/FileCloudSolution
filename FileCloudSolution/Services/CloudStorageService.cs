using FileCloudSolution.DTOs;
using FileCloudSolution.Interfaces;
using FileCloudSolution.Models;

namespace FileCloudSolution.Services;

public class CloudStorageService : ICloudStorageService
{

    private readonly ICloudStorage _repository;

    public CloudStorageService(ICloudStorage repository)
    {
        _repository = repository;
    }

    public void AddFile(string fileName, int size)
    {
        _repository.AddFile(fileName, size);
    }
    public SystemFileDTO AddFile(SystemFileDTO systemFile)
    {
        var file = _repository.GetFileByName(systemFile.Name);

        if (file != null)
            throw new InvalidOperationException("File Already Exists");

        _repository.AddFile(systemFile.Name, systemFile.Size);
        return systemFile;
    }

    public List<SystemFile> GetAllFiles()
    {
        return _repository.GetAllFiles();
    }

    public SystemFile? GetFileByName(string fileName)
    {
        return _repository.GetFileByName(fileName);
    }

    public SystemFile? GetLargestFile()
    {
        return _repository.GetLargestFile();
    }

    public bool Delete(string fileName)
    {
        return _repository.RemoveFile(fileName);
    }
}
