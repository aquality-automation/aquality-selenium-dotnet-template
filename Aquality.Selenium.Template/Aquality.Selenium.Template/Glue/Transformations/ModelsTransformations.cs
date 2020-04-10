using AngleSharp.Common;
using Aquality.Selenium.Template.Models;
using TechTalk.SpecFlow;

namespace Aquality.Selenium.Template.Glue.Transformations
{
    [Binding]
    public class ModelsTransformations
    {
        [StepArgumentTransformation]
        public ContactUsInfo TransformContactUsInfo(Table table)
        {
            var tableData = table.ToDictionary();
            return new ContactUsInfo
            {
                Name = tableData["Name"],
                Company = tableData["Company"],
                Phone = tableData["Phone"],
                Comment = tableData["Comment"]
            };
        }
    }
}
