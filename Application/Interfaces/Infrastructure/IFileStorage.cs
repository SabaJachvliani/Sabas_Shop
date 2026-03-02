namespace Application.Interfaces.Infrastructure
{
    public interface IFileStorage
    {
        Task<string> SaveProductPhotoAsync(
            byte[] content,
            string originalFileName,
            string contentType,
            CancellationToken ct);

        Task DeleteAsync(string relativePath, CancellationToken ct);
    }
}
