using Microsoft.SharePoint;
using Microsoft.SharePoint.Taxonomy;
using SharePointTestConsole.Entities;
using SharePointTestConsole.Repositories;
using System.Collections.Generic;

namespace SharePointTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SPSite site = new SPSite("http://dev.innova.portal"))
            {
                using (SPWeb web = site.OpenWeb("video"))
                {
                    PageLibraryRepository rep = new PageLibraryRepository(web);
                    PageEntity entity = rep.GetItemById(2);
                    SPListItem item = rep.List.GetItemById(2);
                    entity.VideoChannels = new SPFieldLookupValueCollection() { { new SPFieldLookupValue() { LookupId = 1 } }, new SPFieldLookupValue() { LookupId = 2 } };

                    MetadataManager meta = new MetadataManager(web.Site);

                    var taxonomyField = item.Fields.GetFieldByInternalName("VideoTags");
                    TaxonomyFieldValueCollection taxonomyFieldValue = new TaxonomyFieldValueCollection(taxonomyField);

                    var term1 = meta.GetTerm("VideoTags", "Etiket1");
                    var term2 = meta.GetTerm("VideoTags", "Etiket2");
                    var term3 = meta.GetTerm("VideoTags", "Etiket3");

                    TaxonomyFieldValue value1 = new TaxonomyFieldValue(taxonomyField);
                    TaxonomyFieldValue value2 = new TaxonomyFieldValue(taxonomyField);
                    TaxonomyFieldValue value3 = new TaxonomyFieldValue(taxonomyField);
                    value1.Label = "Etiket1";
                    value1.TermGuid = term1.Id.ToString();
                    value2.Label = "Etiket2";
                    value2.TermGuid = term2.Id.ToString();
                    value3.Label = "Etiket3";
                    value3.TermGuid = term3.Id.ToString();

                    taxonomyFieldValue.Add(value1);
                    //taxonomyFieldValue.Add(value2);
                    taxonomyFieldValue.Add(value3);

                    //item["WatchCount"] = 100;
                    //item["VideoTags"] = taxonomyFieldValue;
                    //item.Update();

                    entity.VideoTags = taxonomyFieldValue;
                    entity.WatchCount = 100;

                    rep.AddUpdateItem(entity);



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