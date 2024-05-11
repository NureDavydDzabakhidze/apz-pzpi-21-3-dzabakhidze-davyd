namespace Kolosok.Application.Interfaces.Infrastructure;

public interface IBackupRepository
{
    Task<byte[]> CreateBackupAsync();
    public Task RestoreBackupAsync(byte[] backup);
}