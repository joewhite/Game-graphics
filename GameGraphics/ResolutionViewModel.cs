namespace GameGraphics
{
    public class ResolutionViewModel
    {
        public ResolutionViewModel(int width, int height, int tileWidth, int tileHeight)
        {
            Width = width;
            Height = height;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
        }

        public string Description
        {
            get { return string.Format("{0} x {1}", Width, Height); }
        }
        public string DirectoryName
        {
            get { return string.Format("{0}x{1}", Width, Height); }
        }
        public int Height { get; private set; }
        public bool IsChecked { get; set; }
        public int TileHeight { get; private set; }
        public int TileWidth { get; private set; }
        public int Width { get; private set; }
    }
}