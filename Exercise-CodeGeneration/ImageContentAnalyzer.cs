namespace Exercise_Generation
{
    internal class ImageContentAnalyzer
    {
        public bool IsImageContentSafe(byte[] imageContent)
        {
            return imageContent.Length > 0;
        }
    }
}
