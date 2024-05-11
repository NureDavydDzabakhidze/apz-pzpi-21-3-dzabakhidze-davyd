using System.Diagnostics;
using Kolosok.Application.Interfaces.Infrastructure;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Kolosok.Infrastructure.Repositories;

public class BackupRepository : IBackupRepository
{
    private readonly IConfiguration _configuration;
    
    public BackupRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<byte[]> CreateBackupAsync()
    {
        try
        {
            // Temporarily store the backup in a file
            var backupFilePath = $"backup_{DateTime.Now:yyyyMMddHHmmss}.sql";
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "pg_dump",
                Arguments = $"-U postgres -Fc Kolosok -f {backupFilePath}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                WorkingDirectory = @"D:\University\Course_3_Semester_2\apz\project\Task2\apz-pzpi-21-3-dzabakhidze-davyd-task2\Kolosok\Kolosok.Infrastructure\Backups"
            };

            using var process = Process.Start(processStartInfo);
            await process.WaitForExitAsync();

            // Read the backup file into a byte array
            await using var fileStream = new FileStream(backupFilePath, FileMode.Open, FileAccess.Read);
            using var memoryStream = new MemoryStream();
            await fileStream.CopyToAsync(memoryStream);

            // Delete the temporary backup file
            File.Delete(backupFilePath);

            return memoryStream.ToArray();
        }
        catch (Exception ex)
        {
            throw new Exception("Backup creation failed.", ex);
        }
    }


    public async Task RestoreBackupAsync(byte[] backup)
    {
        try
        {
            using var memoryStream = new MemoryStream(backup);
            await using var connection = new NpgsqlConnection(_configuration.GetConnectionString("KolosokConnectionString"));
            await connection.OpenAsync();

            await using var cmd = new NpgsqlCommand("pg_restore -U postgres -d Kolosok", connection);
            cmd.Parameters.Add(new NpgsqlParameter("data", NpgsqlTypes.NpgsqlDbType.Bytea) { Value = memoryStream.ToArray() });
            await cmd.ExecuteNonQueryAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Backup restoration failed.", ex);
        }
    }
}