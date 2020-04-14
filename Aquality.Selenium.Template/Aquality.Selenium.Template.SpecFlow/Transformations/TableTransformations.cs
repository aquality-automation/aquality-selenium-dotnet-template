using Aquality.Selenium.Template.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Aquality.Selenium.Template.SpecFlow.Transformations
{
    [Binding]
    public class TableTransformations
    {
        [StepArgumentTransformation]
        public ContactUsInfo TransformModel(Table inputTable) => inputTable.CreateInstance<ContactUsInfo>();
    }
}
