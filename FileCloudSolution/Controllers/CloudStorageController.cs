using FileCloudSolution.DTOs;
using FileCloudSolution.Interfaces;
using FileCloudSolution.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileCloudSolution.Controllers;

[ApiController]
[Route("[controller]")]
public class CloudStorageController : Controller
{
    private readonly ILogger<CloudStorageController> _logger;
    private readonly ICloudStorageService _cloudStorageService;

    public CloudStorageController(ILogger<CloudStorageController> logger, ICloudStorageService cloudStorageService)
    {
        _logger = logger;
        _cloudStorageService = cloudStorageService;
    }

    /// <summary>
    /// Returns all files stored in the cloud storage.
    /// </summary>
    [HttpGet(Name = "GetAllFiles")]
    public ActionResult<List<SystemFile>> Get()
    {
        var files = _cloudStorageService.GetAllFiles();

        return Ok(files);
    }

    /// <summary>
    /// Returns a file with the given name.
    /// </summary>
    [HttpGet("{name}")]
    public ActionResult<List<SystemFile>> GetByName([FromRoute] string name)
    {
        var file = _cloudStorageService.GetFileByName(name);

        if (file == null)
            return NotFound($"File '{name}' not found.");

        return Ok(file);
    }

    /// <summary>
    /// Returns the largest file inside the cloud storage.
    /// </summary>
    [HttpGet("largest")]
    public ActionResult<SystemFile> GetLargestFile()
    {
        var file = _cloudStorageService.GetLargestFile();

        if (file == null)
            return NotFound("No files found.");

        return Ok(file);
    }

    /// <summary>
    /// Add new file.
    /// </summary>
    [HttpPost(Name = "AddFile")]
    public ActionResult<SystemFileDTO> Add(SystemFileDTO systemFile)
    {
        if (systemFile == null)
        {
            return BadRequest("Please provide a valid File");
        }

        var createdFile = _cloudStorageService.AddFile(systemFile);

        return CreatedAtAction(
            nameof(Get),
            new { fileName = createdFile.Name },
            createdFile
        );
    }

    /// <summary>
    /// Delete file.
    /// </summary>
    [HttpDelete("{name}")]
    public ActionResult Delete ([FromRoute] string name)
    {
        _cloudStorageService.Delete(name);
        return Ok();
    }
}

