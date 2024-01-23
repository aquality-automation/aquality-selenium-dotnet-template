using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Visualization;
using SkiaSharp;

namespace Aquality.Selenium.Template.Utilities
{
    public class CustomImageComparator
    {
        private readonly ImageComparator imageComparator;

        public CustomImageComparator(float defaultThreshold, int comparisonWidth, int comparisonHeight)
        {
            var visualizationConfiguration = new VisualizationConfiguration(defaultThreshold, comparisonWidth, comparisonHeight);
            imageComparator = new ImageComparator(visualizationConfiguration);
        }

        public float Compare(SKImage firstImage, SKImage secondImage, float? threshold = null)
        {
            return imageComparator.PercentageDifference(firstImage, secondImage, threshold);
        }
    }

    internal class VisualizationConfiguration(float defaultThreshold, int comparisonWidth, int comparisonHeight) : IVisualizationConfiguration
    {
        public float DefaultThreshold { get; } = defaultThreshold;

        public int ComparisonWidth { get; } = comparisonWidth;

        public int ComparisonHeight { get; } = comparisonHeight;

        /// <summary>
        /// This field is not implemented. This field is needed to compare Image Dumps.
        /// </summary>
        public string PathToDumps => throw new System.NotImplementedException();

        /// <summary>
        /// This field is not implemented. This field is needed to compare Image Dumps.
        /// </summary>
        public ImageFormat ImageFormat => throw new System.NotImplementedException();

        /// <summary>
        /// This field is not implemented. This field is needed to compare Image Dumps.
        /// </summary>
        public int MaxFullFileNameLength => throw new System.NotImplementedException();
    }
}
