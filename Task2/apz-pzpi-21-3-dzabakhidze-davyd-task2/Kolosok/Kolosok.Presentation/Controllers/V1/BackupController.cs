using Kolosok.Application.Interfaces.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Kolosok.Presentation.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class BackupController : ControllerBase
{
    private readonly IBackupRepository _backupRepository;

    public BackupController(IBackupRepository backupRepository)
    {
        _backupRepository = backupRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult> GetBackup()
    {
        var backup = await _backupRepository.CreateBackupAsync();
        return File(backup, "application/octet-stream");
    }
    
    [HttpPost]
    public async Task<IActionResult> RestoreBackup([FromBody] byte[] backup)
    {
        await _backupRepository.RestoreBackupAsync(backup);
        return Ok();
    }
}