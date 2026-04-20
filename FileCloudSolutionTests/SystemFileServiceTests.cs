using FileCloudSolution.DTOs;
using FileCloudSolution.Interfaces;
using FileCloudSolution.Models;
using FileCloudSolution.Services;
using Moq;

namespace FileCloudSolutionTests;

public class SystemFileServiceTests
{
    [Fact]
    public void AddFile_ShouldAdd_WhenFileDoesNotExist()
    {
        // Arrange
        var repoMock = new Mock<ISystemFiles>();
        repoMock.Setup(r => r.GetByName("test.txt")).Returns((SystemFile)null);

        var service = new SystemFileService(repoMock.Object);
        var dto = new SystemFileDTO { Name = "test.txt", Size = 100 };

        // Act
        var result = service.AddFile(dto);

        // Assert
        Assert.Equal("test.txt", result.Name);
        Assert.Equal(100, result.Size);
        repoMock.Verify(r => r.Add("test.txt", 100), Times.Once);
    }

    [Fact]
    public void AddFile_ShouldThrow_WhenFileAlreadyExists()
    {
        // Arrange
        var repoMock = new Mock<ISystemFiles>();
        repoMock.Setup(r => r.GetByName("test.txt"))
                .Returns(new SystemFile("test.txt", 100));

        var service = new SystemFileService(repoMock.Object);
        var dto = new SystemFileDTO { Name = "test.txt", Size = 200 };

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => service.AddFile(dto));
    }

    [Fact]
    public void GetAllFiles_ShouldReturnList()
    {
        // Arrange
        var repoMock = new Mock<ISystemFiles>();
        repoMock.Setup(r => r.GetAll())
                .Returns(new List<SystemFile> { new SystemFile("file1", 50) });

        var service = new SystemFileService(repoMock.Object);

        // Act
        var files = service.GetAllFiles();

        // Assert
        Assert.Single(files);
        Assert.Equal("file1", files[0].Name);
    }
}
