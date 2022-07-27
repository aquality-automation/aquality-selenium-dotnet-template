using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Visualization;
using System.Drawing;

namespace Aquality.Selenium.Template.Utilities
{
    public static class CustomImageComparator
    {
        private static IVisualizationConfiguration visualizationConfiguration;

        public static void Init(float defaultThreshold = 0.1F, int comparisonWidth = 20, int comparisonHeight = 20)
        {
            visualizationConfiguration = new VisualizationConfiguration(defaultThreshold, comparisonWidth, comparisonHeight);
        }

        public static float Compare(Image firstImage, Image secondImage, float? threshold = null)
        {
            var imageComparator = new ImageComparator(visualizationConfiguration);
            return imageComparator.PercentageDifference(firstImage, secondImage, threshold);
        }

        private class VisualizationConfiguration : IVisualizationConfiguration
        {
            public float DefaultThreshold { get; }

            public int ComparisonWidth { get; }

            public int ComparisonHeight { get; }

            public string PathToDumps => throw new System.NotImplementedException();

            public VisualizationConfiguration(float defaultThreshold, int comparisonWidth, int comparisonHeight)
            {
                DefaultThreshold = defaultThreshold;
                ComparisonWidth = comparisonWidth;
                ComparisonHeight = comparisonHeight;
            }
        }
    }
}