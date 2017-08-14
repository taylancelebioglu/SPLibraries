namespace SharePoint.Libraries.Entity
{
    public class AttachmentEntity : IAttachmentEntity
    {
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public byte[] FileBytes { get; set; }
    }
}