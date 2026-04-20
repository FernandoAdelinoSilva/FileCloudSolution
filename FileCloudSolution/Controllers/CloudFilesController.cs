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

    [HttpGet("{name}")]
    public ActionResult<List<SystemFile>> GetByName([FromRoute] string name)
    {
        var file = _systemFileService.GetFileByName(name);

        if (file == null)
            return NotFound($"File '{name}' not found.");

        return Ok(file);
    }

    [HttpGet("largest")]
    public ActionResult<SystemFile> GetLargestFile()
    {
        var file = _systemFileService.GetLargestFile();

        if (file == null)
            return NotFound("No files found.");

        return Ok(file);
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

    [HttpDelete("{name}")]
    public ActionResult Delete ([FromRoute] string name)
    {
        _systemFileService.Delete(name);
        return Ok();
    }
}

