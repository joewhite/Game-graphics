namespace GameGraphics.Core
{
    public class SceneOptions
    {
        public SceneOptions(string imageDirectory, int tileWidth, int tileHeight)
        {
            ImageDirectory = imageDirectory;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
        }

        public string ImageDirectory { get; private set; }
        public int TileHeight { get; private set; }
        public int TileWidth { get; private set; }
    }
}