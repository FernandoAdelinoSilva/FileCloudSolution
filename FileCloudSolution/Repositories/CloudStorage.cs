using FileCloudSolution.Interfaces;
using FileCloudSolution.Models;
using System.Drawing;

namespace FileCloudSolution.Repositories;

public class CloudStorage : ICloudStorage
{
    private List<SystemFile> _systemFiles { get; set; } = new List<SystemFile>();

    public void AddFile(string fileName, int size)
    {
        var file = new SystemFile(fileName, size);
        _systemFiles.Add(file);
    }

    public bool RemoveFile(string fileName)
    {
        var file = _systemFiles.FirstOrDefault(f => f.Name.Equals(fileName));

        if (file != null)
        {
            _systemFiles.Remove(file);
            return true;
        }
        return false;
    }

    public List<SystemFile> GetAllFiles()
    {
        return _systemFiles;
    }

    public SystemFile? GetFileByName(string fileName)
    {
        return _systemFiles.FirstOrDefault(f => f.Name.Equals(fileName));
    }

    public SystemFile? GetLargestFile()
    {
        return _systemFiles.OrderByDescending(f => f.Size).FirstOrDefault();
    }
}
