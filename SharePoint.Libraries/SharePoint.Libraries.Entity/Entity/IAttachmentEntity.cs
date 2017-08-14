namespace SharePoint.Libraries.Entity
{
    public interface IAttachmentEntity
    {
        string FileName { get; set; }
        string FileUrl { get; set; }
        byte[] FileBytes { get; set; }
    }
}