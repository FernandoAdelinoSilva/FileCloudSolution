using FileCloudSolution.Interfaces;
using FileCloudSolution.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileCloudSolution.Controllers;

[ApiController]
[Route("[controller]")]
public class CloudFilesController : Controller
{
    private readonly ILogger<CloudFilesController> _logger;
    private readonly ISystemFileService _systemFileService;

    public CloudFilesController(ILogger<CloudFilesController> logger, ISystemFileService systemFileService)
    {
        _logger = logger;
        _systemFileService = systemFileService;
    }

    [HttpGet(Name = "GetAllFiles")]
    public List<SystemFile> Get()
    {
        _systemFileService.AddFile("test", 1);
        return _systemFileService.GetAllFiles();
    }
}

