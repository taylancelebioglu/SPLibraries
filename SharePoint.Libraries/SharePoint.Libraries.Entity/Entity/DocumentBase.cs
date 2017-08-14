namespace SharePoint.Libraries.Entity
{
    public class DocumentBase : EntityBase, IDocumentEntity
    {
        public string FileUrl { get; set; }
        public string FileName { get; set; }
        public string FileIconUrl { get; set; }
    }
}