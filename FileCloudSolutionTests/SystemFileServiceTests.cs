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

    [Fact]
    public void GetFileByName_ShouldReturnFile_WhenExists()
    {
        // Arrange
        var repoMock = new Mock<ISystemFiles>();
        repoMock.Setup(r => r.GetByName("file1"))
                .Returns(new SystemFile("file1", 100));

        var service = new SystemFileService(repoMock.Object);

        // Act
        var result = service.GetFileByName("file1");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("file1", result.Name);
        Assert.Equal(100, result.Size);
    }

    [Fact]
    public void GetFileByName_ShouldReturnNull_WhenNotExists()
    {
        // Arrange
        var repoMock = new Mock<ISystemFiles>();
        repoMock.Setup(r => r.GetByName("file1"))
                .Returns((SystemFile?)null);

        var service = new SystemFileService(repoMock.Object);

        // Act
        var result = service.GetFileByName("file1");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Delete_ShouldReturnTrue_WhenFileExists()
    {
        // Arrange
        var repoMock = new Mock<ISystemFiles>();
        repoMock.Setup(r => r.Remove("file1")).Returns(true);

        var service = new SystemFileService(repoMock.Object);

        // Act
        var result = service.Delete("file1");

        // Assert
        Assert.True(result);
        repoMock.Verify(r => r.Remove("file1"), Times.Once);
    }

    [Fact]
    public void Delete_ShouldReturnFalse_WhenFileDoesNotExist()
    {
        // Arrange
        var repoMock = new Mock<ISystemFiles>();
        repoMock.Setup(r => r.Remove("file1")).Returns(false);

        var service = new SystemFileService(repoMock.Object);

        // Act
        var result = service.Delete("file1");

        // Assert
        Assert.False(result);
        repoMock.Verify(r => r.Remove("file1"), Times.Once);
    }

    [Fact]
    public void GetLargestFile_ShouldReturnFile_WhenFilesExist()
    {
        // Arrange
        var largestFile = new SystemFile("bigfile.txt", 500);
        var repoMock = new Mock<ISystemFiles>();
        repoMock.Setup(r => r.GetLargestFile()).Returns(largestFile);

        var service = new SystemFileService(repoMock.Object);

        // Act
        var result = service.GetLargestFile();

        // Assert
        Assert.NotNull(result);
        Assert.Equal("bigfile.txt", result.Name);
        Assert.Equal(500, result.Size);
        repoMock.Verify(r => r.GetLargestFile(), Times.Once);
    }

    [Fact]
    public void GetLargestFile_ShouldReturnNull_WhenNoFilesExist()
    {
        // Arrange
        var repoMock = new Mock<ISystemFiles>();
        repoMock.Setup(r => r.GetLargestFile()).Returns((SystemFile?)null);

        var service = new SystemFileService(repoMock.Object);

        // Act
        var result = service.GetLargestFile();

        // Assert
        Assert.Null(result);
        repoMock.Verify(r => r.GetLargestFile(), Times.Once);
    }
}
