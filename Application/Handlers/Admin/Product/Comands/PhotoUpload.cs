namespace Application.Handlers.Admin.Product.Comands
{
    public sealed record PhotoUpload(byte[] Content, string FileName, string ContentType);
}
