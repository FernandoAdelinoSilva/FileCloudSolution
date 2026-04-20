using FileCloudSolution.Models;
using System.Drawing;

namespace FileCloudSolution.Repositories;

public class SystemFiles
{
    private List<SystemFile> _systemFiles { get; set; } = new List<SystemFile>();

    public void Add(string fileName, int size)
    {
        var file = new SystemFile(fileName, size);
        _systemFiles.Add(file);
    }

    public bool Remove(string fileName)
    {
        var file = _systemFiles.FirstOrDefault(f => f.Name.Equals(fileName));

        if (file != null)
        {
            _systemFiles.Remove(file);
            return true;
        }
        return false;
    }

    public List<SystemFile> GetAll()
    {
        return _systemFiles;
    }

    public SystemFile GetByName(string fileName)
    {
        return _systemFiles.FirstOrDefault(f => f.Name.Equals(fileName));
    }
}
