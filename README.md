<p><strong>SPLibraries Entity (SharePoint.Libraries.Entity)</strong></p>
<p>&nbsp;</p>
<p>This mapper can be easily implemented to a Project by defining entity and repository classes. I helps converting list item to your custom entity or vice versa.</p>
<p>By using repository base classes you will get basic methods without any coding and because of the perfomance concern it will add view fields to your query according to the entity properties unless otherwise specified.</p>
<p>It supports all most common SharePoint fields including publishing and taxonomy fields.</p>
<p>&nbsp;</p>
<p><strong>Entities</strong></p>
<p>&nbsp;</p>
<p>You need to derive you custom entity from EntityBase class. By doing that you will get basic SP fields such as ID, CreatedBy, Modified.</p>
<p>&nbsp;</p>
<p>#region Assembly SharePoint.Libraries.Entity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=0be90ed3695f8b28</p>
<p>// C:\Users\sa_spadmin\Source\Repos\SPLibraries\SharePoint.Libraries\packages\SharePoint.Libraries.Entity.1.0.2\lib\net452\SharePoint.Libraries.Entity.dll</p>
<p>#endregion</p>
<p>&nbsp;</p>
<p>using System;</p>
<p>using System.Collections.Generic;</p>
<p>using Microsoft.SharePoint;</p>
<p>&nbsp;</p>
<p>namespace SharePoint.Libraries.Entity</p>
<p>{</p>
<p>&nbsp;&nbsp;&nbsp; public class EntityBase : IEntity</p>
<p>&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public EntityBase();</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [SPFieldFlag(Name = "ID", RestrictUpdate = true)]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public int Id { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [SPFieldFlag(Name = "Title")]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public string Title { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [SPFieldFlag]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public DateTime Created { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [SPFieldFlag]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public DateTime Modified { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [SPFieldFlag(Name = "Editor")]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public SPFieldUserValue ModifiedBy { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [SPFieldFlag(Name = "Author")]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public SPFieldUserValue CreatedBy { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [SPFieldFlag]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public List&lt;IAttachmentEntity&gt; Attachments { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp; }</p>
<p>}</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>This is a sample entity, you can see the description of properties. I tried to add all frequently used fields.</p>
<p>using Microsoft.SharePoint;</p>
<p>using Microsoft.SharePoint.Taxonomy;</p>
<p>using SharePoint.Libraries.Entity;</p>
<p>using System;</p>
<p>&nbsp;</p>
<p>namespace SharePointTestConsole.Entities</p>
<p>{</p>
<p>&nbsp;&nbsp;&nbsp; public class CustomTestEntity : EntityBase</p>
<p>&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [SPFieldFlag]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public string ChoiceField { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [SPFieldFlag]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public int NumberField { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// can be givven a different name rather than sp field's internal name</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [SPFieldFlag(Name = "CurrencyField")]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public double Currency { get; set; }</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// This field won't be updated when AddUpdateItem method executed.</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [SPFieldFlag(RestrictUpdate = true)]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public DateTime? DateTimeField { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [SPFieldFlag(Name = "YesNoField")]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public bool BooleanField { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [SPFieldFlag]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public SPFieldUserValue PersonField { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [SPFieldFlag]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public SPFieldUrlValue HyperlinkField { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// for multiple fields use 'TaxonomyFieldValueCollection'</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [SPFieldFlag]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public TaxonomyFieldValue MetadataField { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [SPFieldFlag]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public SPFieldLookupValue LookupSingleField { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [SPFieldFlag]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public SPFieldLookupValueCollection LookupMultiField { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [SPFieldFlag]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public string PublishingPageContent { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [SPFieldFlag]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public DateTime? PublishingStartDate { get; set; }</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// This property won't be mapped because of lack of the SPFieldFlag attribute. It is for only internal use.</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public string InternalProperty { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp; }</p>
<p>}</p>
<p>&nbsp;</p>
<p>If you want to work document libraries, your entity should be derived from DocumentBase class</p>
<p>using SharePoint.Libraries.Entity;</p>
<p>&nbsp;</p>
<p>namespace SharePointTestConsole.Entities</p>
<p>{</p>
<p>&nbsp;&nbsp;&nbsp; public class LibraryEntity : DocumentBase</p>
<p>&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //Custom fields</p>
<p>&nbsp;&nbsp;&nbsp; }</p>
<p>}</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><strong>Repositories</strong></p>
<p>&nbsp;</p>
<p>using SharePoint.Libraries.Entity;</p>
<p>using SharePointTestConsole.Entities;</p>
<p>using Microsoft.SharePoint;</p>
<p>using System.Collections.Generic;</p>
<p>&nbsp;</p>
<p>namespace SharePointTestConsole.Repositories</p>
<p>{</p>
<p>&nbsp;&nbsp;&nbsp; public class CustomTestEntityRepository : RepositoryBase&lt;CustomTestEntity&gt;</p>
<p>&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected override string ListUrl =&gt; "Lists/CustomTestList";</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public CustomTestEntityRepository(SPWeb web) : base(web)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// You can easily pass your custom query to the base GetItems method. If you don't specify any view field, base repository is going to add view fields according to your entity.</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// You don't need any custom method for Add/Update/Delete item, get allitems, getitembyId operations.</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;returns&gt;&lt;/returns&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public IList&lt;CustomTestEntity&gt; GetItemsByOrder()</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SPQuery orderQuery = new SPQuery();</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; orderQuery.Query = "&lt;OrderBy&gt;&lt;FieldRef Name='DateTimeField' /&gt;&lt;/OrderBy&gt;";</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return base.GetItems(orderQuery);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;&nbsp;&nbsp; }</p>
<p>}</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>using SharePoint.Libraries.Entity;</p>
<p>using Microsoft.SharePoint;</p>
<p>&nbsp;</p>
<p>namespace SharePointTestConsole.Repositories</p>
<p>{</p>
<p>&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;</p>
<p>&nbsp;&nbsp;&nbsp; /// If you want to work with list items, use SPRepositoryBase</p>
<p>&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;</p>
<p>&nbsp;&nbsp;&nbsp; public class CustomTestSPRepository : SPRepositoryBase</p>
<p>&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected override string ListUrl =&gt; "Lists/CustomTestList";</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public CustomTestSPRepository(SPWeb web) : base(web)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public SPListItemCollection GetItemsByOrder()</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SPQuery orderQuery = new SPQuery();</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; orderQuery.Query = "&lt;OrderBy&gt;&lt;FieldRef Name='DateTimeField' /&gt;&lt;/OrderBy&gt;";</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return base.GetItems(orderQuery);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;&nbsp;&nbsp; }</p>
<p>}</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>using SharePoint.Libraries.Entity;</p>
<p>using SharePointTestConsole.Entities;</p>
<p>using Microsoft.SharePoint;</p>
<p>&nbsp;</p>
<p>namespace SharePointTestConsole.Repositories</p>
<p>{</p>
<p>&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;</p>
<p>&nbsp;&nbsp;&nbsp; /// This repository is being used for quering by 'SPSiteDataQuery'</p>
<p>&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;</p>
<p>&nbsp;&nbsp;&nbsp; public class CustomTestEntitySiteRepository : SiteRepositoryBase&lt;CustomTestEntity&gt;</p>
<p>&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public CustomTestEntitySiteRepository(SPWeb web) : base(web)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;&nbsp;&nbsp; }</p>
<p>}</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>using SharePoint.Libraries.Entity;</p>
<p>using Microsoft.SharePoint;</p>
<p>using SharePointTestConsole.Entities;</p>
<p>&nbsp;</p>
<p>namespace SharePointTestConsole.Repositories</p>
<p>{</p>
<p>&nbsp;&nbsp;&nbsp; public class ImagesLibraryRepository : RepositoryBase&lt;LibraryEntity&gt;</p>
<p>&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected override string ListUrl =&gt; "PublishingImages";</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public ImagesLibraryRepository(SPWeb web) : base(web)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;&nbsp;&nbsp; }</p>
<p>}</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>using Microsoft.SharePoint;</p>
<p>using SharePointTestConsole.Entities;</p>
<p>using SharePointTestConsole.Repositories;</p>
<p>using System.Collections.Generic;</p>
<p>&nbsp;</p>
<p>namespace SharePointTestConsole</p>
<p>{</p>
<p>&nbsp;&nbsp;&nbsp; class Program</p>
<p>&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; static void Main(string[] args)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; using (SPSite site = new SPSite("http://dev.sp2016"))</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; using (SPWeb web = site.RootWeb)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CustomTestEntityRepository listRep = new CustomTestEntityRepository(web);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var orderedItems = listRep.GetItemsByOrder();</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CustomTestSPRepository spRep = new CustomTestSPRepository(web);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SPListItemCollection spItems = spRep.GetItemsByOrder();</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Can be used for any library such as Pages</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ImagesLibraryRepository libraryRep = new ImagesLibraryRepository(web);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; IList&lt;LibraryEntity&gt; imagesDocs = libraryRep.GetItems();</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // You can easily update a document to a library or attach to a list item.</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; libraryRep.AddDocument("NewFolder/Image", "UploadFilePath.jpg");</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // You can't get all SP fields via SPSiteDataQuery!</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SPSiteDataQuery dataQuery = new SPSiteDataQuery();</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dataQuery.Webs = "&lt;Webs Scope=\"Recursive\"&gt;";</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dataQuery.Lists = "&lt;Lists ServerTemplate=\"100\" /&gt;";</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dataQuery.ViewFields = "&lt;FieldRef Name=\"Title\" /&gt;&lt;FieldRef Name=\"ID\" /&gt;&lt;FieldRef Name=\"NumberField\" /&gt;&lt;FieldRef Name=\"NumberField\" /&gt;&lt;FieldRef Name=\"DateTimeField\" /&gt;";</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dataQuery.Query = "&lt;Where&gt;&lt;Eq&gt;&lt;FieldRef Name=\"Title\"/&gt;&lt;Value Type='Text'&gt;Test item 1 title&lt;/Value&gt;&lt;/Eq&gt;&lt;/Where&gt;";</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CustomTestEntitySiteRepository siteRep = new CustomTestEntitySiteRepository(web);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; IList&lt;CustomTestEntity&gt; dataResult = siteRep.GetItems(dataQuery);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;&nbsp;&nbsp; }</p>
<p>}</p>
<p>&nbsp;</p>
<p><strong>RepositoryBase Public Members</strong></p>
<table>
<tbody>
<tr>
<td width="604">
<p>GetItemById(int id)</p>
</td>
</tr>
<tr>
<td width="604">
<p>GetItems()</p>
</td>
</tr>
<tr>
<td width="604">
<p>GetItems(SPQuery query)</p>
</td>
</tr>
<tr>
<td width="604">
<p>GetAllItems()</p>
</td>
</tr>
<tr>
<td width="604">
<p>GetItemsAndPosition(SPQuery spQuery, out SPListItemCollectionPosition position)</p>
</td>
</tr>
<tr>
<td width="604">
<p>ConvertToEntity(SPListItem item)</p>
</td>
</tr>
<tr>
<td width="604">
<p>AddUpdateItem(T entity)</p>
</td>
</tr>
<tr>
<td width="604">
<p>SystemUpdateItem(T entity, bool incrementListItemVersion)</p>
</td>
</tr>
<tr>
<td width="604">
<p>AddDocument(string folderUrl, string filePath)</p>
</td>
</tr>
<tr>
<td width="604">
<p>SPFolder GetFolder(string folderUrl)</p>
</td>
</tr>
<tr>
<td width="604">
<p>DeleteItem(int Id)</p>
</td>
</tr>
<tr>
<td width="604">
<p>List</p>
</td>
</tr>
</tbody>
</table>
<p><strong>&nbsp;</strong></p>
<p>&nbsp;</p>