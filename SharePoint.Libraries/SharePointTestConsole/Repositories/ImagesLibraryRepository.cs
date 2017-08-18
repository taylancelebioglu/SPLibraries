using SharePoint.Libraries.Entity;
using Microsoft.SharePoint;
using SharePointTestConsole.Entities;

namespace SharePointTestConsole.Repositories
{
    public class ImagesLibraryRepository : RepositoryBase<LibraryEntity>
    {
        protected override string ListUrl => "PublishingImages";
        public ImagesLibraryRepository(SPWeb web) : base(web)
        {
        }
    }
}