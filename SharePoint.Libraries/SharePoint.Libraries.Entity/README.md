
# SPLibraries Entity (SharePoint.Libraries.Entity)
 
This mapper can be easily implemented to a Project by defining entity and repository classes. I helps converting list item to your custom entity or vice versa.
By using repository base classes you will get basic methods without any coding and because of the perfomance concern it will add view fields to your query according to the entity properties unless otherwise specified.
It supports all most common SharePoint fields including publishing and taxonomy fields.
 
## Entities
 
You need to derive you custom entity from EntityBase class. By doing that you will get basic SP fields such as ID, CreatedBy, Modified.

```csharp
 
using System;
using System.Collections.Generic;
using Microsoft.SharePoint;
 
namespace SharePoint.Libraries.Entity
{
    public class EntityBase : IEntity
    {
        public EntityBase();
 
        [SPFieldFlag(Name = "ID", RestrictUpdate = true)]
        public int Id { get; set; }
        [SPFieldFlag(Name = "Title")]
        public string Title { get; set; }
        [SPFieldFlag]
        public DateTime Created { get; set; }
        [SPFieldFlag]
        public DateTime Modified { get; set; }
        [SPFieldFlag(Name = "Editor")]
        public SPFieldUserValue ModifiedBy { get; set; }
        [SPFieldFlag(Name = "Author")]
        public SPFieldUserValue CreatedBy { get; set; }
        [SPFieldFlag]
        public List<IAttachmentEntity> Attachments { get; set; }
    }
}
```
 
This is a sample entity, you can see the description of properties. I tried to add all frequently used fields. 

```csharp
using Microsoft.SharePoint;
using Microsoft.SharePoint.Taxonomy;
using SharePoint.Libraries.Entity;
using System;
 
namespace SharePointTestConsole.Entities
{
    public class CustomTestEntity : EntityBase
    {
        [SPFieldFlag]
        public string ChoiceField { get; set; }
        [SPFieldFlag]
        public int NumberField { get; set; }
        /// <summary>
        /// can be given a different name rather than sp field's internal name
        /// </summary>
        [SPFieldFlag(Name = "CurrencyField")]
        public double Currency { get; set; }
 
        /// <summary>
        /// This field won't be updated when AddUpdateItem method executed.
        /// </summary>
        [SPFieldFlag(RestrictUpdate = true)]
        public DateTime? DateTimeField { get; set; }
        [SPFieldFlag(Name = "YesNoField")]
        public bool BooleanField { get; set; }
        [SPFieldFlag]
        public SPFieldUserValue PersonField { get; set; }
        [SPFieldFlag]
        public SPFieldUrlValue HyperlinkField { get; set; }
        /// <summary>
        /// for multiple fields use 'TaxonomyFieldValueCollection'
        /// </summary>
        [SPFieldFlag]
        public TaxonomyFieldValue MetadataField { get; set; }
        [SPFieldFlag]
        public SPFieldLookupValue LookupSingleField { get; set; }
        [SPFieldFlag]
        public SPFieldLookupValueCollection LookupMultiField { get; set; }
        [SPFieldFlag]
        public string PublishingPageContent { get; set; }
        [SPFieldFlag]
        public DateTime? PublishingStartDate { get; set; }
 
        /// <summary>
        /// This property won't be mapped because of lack of the SPFieldFlag attribute. It is for only internal use.
        /// </summary>
        public string InternalProperty { get; set; }
    }
}
 ```

If you want to work document libraries, your entity should be derived from DocumentBase class
using SharePoint.Libraries.Entity;
 
```csharp
namespace SharePointTestConsole.Entities
{
    public class LibraryEntity : DocumentBase
    {
        //Custom fields
    }
}
``` 
 
## Repositories
 
```csharp
using SharePoint.Libraries.Entity;
using SharePointTestConsole.Entities;
using Microsoft.SharePoint;
using System.Collections.Generic;
 
namespace SharePointTestConsole.Repositories
{
    public class CustomTestEntityRepository : RepositoryBase<CustomTestEntity>
    {
        protected override string ListUrl => "Lists/CustomTestList";
        public CustomTestEntityRepository(SPWeb web) : base(web)
        {
        }
 
        /// <summary>
        /// You can easily pass your custom query to the base GetItems method. If you don't specify any view field, base repository is going to add view fields according to your entity.
        /// You don't need any custom method for Add/Update/Delete item, get allitems, getitembyId operations.
        /// </summary>
        /// <returns></returns>
        public IList<CustomTestEntity> GetItemsByOrder()
        {
            SPQuery orderQuery = new SPQuery();
            orderQuery.Query = "<OrderBy><FieldRef Name='DateTimeField' /></OrderBy>";
            return base.GetItems(orderQuery);
        }
    }
}
 
 
using SharePoint.Libraries.Entity;
using Microsoft.SharePoint;
 
namespace SharePointTestConsole.Repositories
{
    /// <summary>
    /// If you want to work with list items, use SPRepositoryBase 
    /// </summary>
    public class CustomTestSPRepository : SPRepositoryBase
    {
        protected override string ListUrl => "Lists/CustomTestList";
        public CustomTestSPRepository(SPWeb web) : base(web)
        {
        }
        public SPListItemCollection GetItemsByOrder()
        {
            SPQuery orderQuery = new SPQuery();
            orderQuery.Query = "<OrderBy><FieldRef Name='DateTimeField' /></OrderBy>";
            return base.GetItems(orderQuery);
        }
    }
}
 
 
using SharePoint.Libraries.Entity;
using SharePointTestConsole.Entities;
using Microsoft.SharePoint;
 
namespace SharePointTestConsole.Repositories
{
    /// <summary>
    /// This repository is being used for quering by 'SPSiteDataQuery'
    /// </summary>
    public class CustomTestEntitySiteRepository : SiteRepositoryBase<CustomTestEntity>
    {
        public CustomTestEntitySiteRepository(SPWeb web) : base(web)
        {
        }
    }
}
 
 
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
```

## Sample Usage

<img width=800 id="listView"
src="https://raw.githubusercontent.com/taylancelebioglu/SPLibraries/master/Files/SPEntity/ListView.jpg"></p>

<p>&nbsp;</p>

<img width=356 id="repositoryMethods"
src="https://raw.githubusercontent.com/taylancelebioglu/SPLibraries/master/Files/SPEntity/RepositoryMethods.jpg"></p>

<p>&nbsp;</p>

<img width=604 id="Result"
src="https://raw.githubusercontent.com/taylancelebioglu/SPLibraries/master/Files/SPEntity/Result.jpg"></p>

<p>&nbsp;</p>

<img width=605 id="Attachment"
src="https://raw.githubusercontent.com/taylancelebioglu/SPLibraries/master/Files/SPEntity/Attachment.jpg"></p>

<p>&nbsp;</p>

<img width=604 id="imagesLibrary"
src="https://raw.githubusercontent.com/taylancelebioglu/SPLibraries/master/Files/SPEntity/images_libraryRep.jpg"></p>

<p>&nbsp;</p>

<img width=750 id="siteRepository"
src="https://raw.githubusercontent.com/taylancelebioglu/SPLibraries/master/Files/SPEntity/SiteRepository.jpg"></p>

<p>&nbsp;</p>

```csharp
using Microsoft.SharePoint;
using SharePointTestConsole.Entities;
using SharePointTestConsole.Repositories;
using System.Collections.Generic;
 
namespace SharePointTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SPSite site = new SPSite("http://dev.sp2016"))
            {
                using (SPWeb web = site.RootWeb)
                {
                    CustomTestEntityRepository listRep = new CustomTestEntityRepository(web);
                    var orderedItems = listRep.GetItemsByOrder();
 
                    CustomTestSPRepository spRep = new CustomTestSPRepository(web);
                    SPListItemCollection spItems = spRep.GetItemsByOrder();
 
                    // Can be used for any library such as Pages
                    ImagesLibraryRepository libraryRep = new ImagesLibraryRepository(web);
                    IList<LibraryEntity> imagesDocs = libraryRep.GetItems();
 
                    // You can easily update a document to a library or attach to a list item.
                    libraryRep.AddDocument("NewFolder/Image", "UploadFilePath.jpg");
 
 
                    // You can't get all SP fields via SPSiteDataQuery!
                    SPSiteDataQuery dataQuery = new SPSiteDataQuery();
                    dataQuery.Webs = "<Webs Scope=\"Recursive\">";
                    dataQuery.Lists = "<Lists ServerTemplate=\"100\" />";
                    dataQuery.ViewFields = "<FieldRef Name=\"Title\" /><FieldRef Name=\"ID\" /><FieldRef Name=\"NumberField\" /><FieldRef Name=\"NumberField\" /><FieldRef Name=\"DateTimeField\" />";
                    dataQuery.Query = "<Where><Eq><FieldRef Name=\"Title\"/><Value Type='Text'>Test item 1 title</Value></Eq></Where>";
 
                    CustomTestEntitySiteRepository siteRep = new CustomTestEntitySiteRepository(web);
                    IList<CustomTestEntity> dataResult = siteRep.GetItems(dataQuery);
                }
            }
        }
    }
}
```
<p>&nbsp;</p>

|RepositoryBase Public Members
|--------------------------------
|GetItemById(int id)
|GetItemById(int id)
|GetItems()
|GetItems(SPQuery query)
|GetAllItems()
|GetItemsAndPosition(SPQuery spQuery, out SPListItemCollectionPosition position)
|ConvertToEntity(SPListItem item)
|AddUpdateItem(T entity)
|SystemUpdateItem(T entity, bool incrementListItemVersion)
|AddDocument(string folderUrl, string filePath)
|SPFolder GetFolder(string folderUrl)
|DeleteItem(int Id)
|List
