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