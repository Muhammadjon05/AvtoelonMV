using Microsoft.AspNetCore.Http;

namespace AvtoElonData.FileHelper;

public static class Helper
{
    private const string WwwRoot = "wwwroot";
    private static void Save(string folder)
    {
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
    }
    public static async Task<string> SaveProduct(IFormFile file)
    {
        return await SaveFiles(file, "ProductPhoto");
    }
    private static async Task<string> SaveFiles(IFormFile file, string folder)
    {
        Save(Path.Combine(WwwRoot, folder));
        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var ms = new MemoryStream();
        await file.CopyToAsync(ms);
        await File.WriteAllBytesAsync($"{WwwRoot}//{folder}//{fileName}", ms.ToArray());
        return $"/{folder}/{fileName}";
    }
}