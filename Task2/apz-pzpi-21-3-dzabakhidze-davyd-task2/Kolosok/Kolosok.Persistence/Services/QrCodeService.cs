using System.Drawing;
using IronBarCode;
using Newtonsoft.Json;


namespace Kolosok.Persistence.Services;

public class QRCodeService
{
    public async Task<byte[]> GenerateQRCode<T>(T entity) where T : class
    {
        // Convert entity to JSON string
        var json = JsonConvert.SerializeObject(entity);
        var filePath = Path.Combine(@"D:\", "MyQR.png");
        QRCodeWriter.CreateQrCode(json).SaveAsPng(filePath);
        var pngBytes = await File.ReadAllBytesAsync(filePath);
        // File.Delete(filePath);
        
        return pngBytes;
    }
    
    public async Task<T> ReadQRCode<T>(byte[] qrCodeBytes) where T : class
    {
        var result = await BarcodeReader.ReadAsync(qrCodeBytes,
            new BarcodeReaderOptions() { ExpectBarcodeTypes = BarcodeEncoding.QRCode });
        var entity = JsonConvert.DeserializeObject<T>(result.First().Value);
        
        return entity;
    }
}
