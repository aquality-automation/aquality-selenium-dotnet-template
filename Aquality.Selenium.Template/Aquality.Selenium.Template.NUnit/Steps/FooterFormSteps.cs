using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Logging;
using Aquality.Selenium.Template.CustomAttributes;
using Aquality.Selenium.Template.Forms;
using Aquality.Selenium.Template.NUnit.Extensions;
using NUnit.Framework;
using System.IO;

namespace Aquality.Selenium.Template.NUnit.Steps
{
    public class FooterFormSteps
    {
        private static Logger Logger => Logger.Instance;
        private readonly FooterForm footerForm = new FooterForm();

        [LogStep(StepType.Assertion)]
        public void FooterFormIsPresent()
        {
            footerForm.AssertIsPresent();
        }

        [LogStep(StepType.Assertion)]
        public void CheckVisualElementsPresent()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(footerForm.IsLogoPresent, "Logo should be displayed");
                Assert.IsTrue(footerForm.IsContactsPresent, "Contacts section should be displayed");
                Assert.IsTrue(footerForm.IsSubscribePresent, "Subscribe section should be displayed");
            });
        }

        [LogStep(StepType.Step)]
        public void SaveDump()
        {
            footerForm.Dump.Save();
        }

        [LogStep(StepType.Assertion)]
        public void CheckThatTheVisualElementsAreCorrect()
        {
            var dir = AqualityServices.Get<IVisualizationConfiguration>().PathToDumps;
            Logger.Info($"Directory - {dir}");
            DirectoryInfo d = new DirectoryInfo(dir);
            Logger.Info($" DirectoryInfo - {d.FullName}");
            var temp = d.GetDirectories()[0].GetFiles();
            foreach (var item in temp)
            {
                Logger.Info($"file info - [{item.FullName}]");
            }
            var compareVisualElements = footerForm.Dump.Compare();
            Assert.AreEqual(0, compareVisualElements, "The footer form should contain the correct visual elements");
        }
    }
}
