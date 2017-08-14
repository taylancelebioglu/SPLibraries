namespace SharePoint.Libraries.Entity
{
    public interface IDocumentEntity : IEntity
    {
        string FileUrl { get; set; }
        string FileName { get; set; }
        string FileIconUrl { get; set; }
    }
}
