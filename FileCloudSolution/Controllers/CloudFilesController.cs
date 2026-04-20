using FileCloudSolution.DTOs;
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
    public ActionResult<List<SystemFile>> Get()
    {
        var files = _systemFileService.GetAllFiles();

        return Ok(files);
    }

    [HttpPost(Name = "AddFile")]
    public ActionResult<SystemFileDTO> Add(SystemFileDTO systemFile)
    {
        if (systemFile == null)
        {
            return BadRequest("Please provide a valid File");
        }

        var createdFile = _systemFileService.AddFile(systemFile);

        return CreatedAtAction(
            nameof(Get),
            new { fileName = createdFile.Name },
            createdFile
        );
    }
}

