namespace FileCloudSolution.Models;

public class SystemFile
{
    public string? Name { get; set; }
    public int Size { get; set; }

    public SystemFile(string? name, int size)
    {
        Name = name;
        Size = size;
    }
}
