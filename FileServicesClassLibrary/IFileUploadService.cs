namespace FileServicesClassLibrary
{
    public interface IFileUploadService
    {
        public Task<string> SaveFileAsync(DocEntity file);
    }
}