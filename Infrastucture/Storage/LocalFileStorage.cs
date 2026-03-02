using Application.Interfaces.Infrastructure;
using Microsoft.AspNetCore.Hosting;

namespace Infrastucture.Storage
{
    public sealed class LocalFileStorage : IFileStorage
    {
        private readonly IWebHostEnvironment _env;

        public LocalFileStorage(IWebHostEnvironment env) => _env = env;

        public async Task<string> SaveProductPhotoAsync(
            byte[] content,
            string originalFileName,
            string contentType,
            CancellationToken ct)
        {
            var ext = Path.GetExtension(originalFileName);
            if (string.IsNullOrWhiteSpace(ext)) ext = ".jpg";

            var fileName = $"{Guid.NewGuid():N}{ext}";
            var relative = Path.Combine("uploads", "products", fileName);
            var fullPath = Path.Combine(_env.WebRootPath, relative);

            Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);

            await File.WriteAllBytesAsync(fullPath, content, ct);

            // return URL-friendly path
            return "/" + relative.Replace("\\", "/");
        }

        public Task DeleteAsync(string relativePath, CancellationToken ct)
        {
            var cleaned = relativePath.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString());
            var fullPath = Path.Combine(_env.WebRootPath, cleaned);

            if (File.Exists(fullPath))
                File.Delete(fullPath);

            return Task.CompletedTask;
        }
    }
}
