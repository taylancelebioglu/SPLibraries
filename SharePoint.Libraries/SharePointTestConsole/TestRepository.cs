using Microsoft.SharePoint;
using SharePoint.Libraries.Entity;

namespace SharePointTestConsole
{
    public class TestRepository : RepositoryBase<TestEntity>
    {
        public TestRepository(SPWeb web) : base(web)
        {

        }
        protected override string ListUrl => "Lists/test";
    }
}