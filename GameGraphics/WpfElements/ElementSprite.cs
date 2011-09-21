using System.Windows.Controls;
using GameGraphics.Core;

namespace GameGraphics.WpfElements
{
    public class ElementSprite : ISprite
    {
        private readonly Image _imageElement;
        private readonly SceneOptions _sceneOptions;

        public ElementSprite(Image imageElement, SceneOptions sceneOptions)
        {
            _imageElement = imageElement;
            _sceneOptions = sceneOptions;
        }

        public double X
        {
            get { return Canvas.GetLeft(_imageElement) / _sceneOptions.TileWidth; }
            set { Canvas.SetLeft(_imageElement, value * _sceneOptions.TileWidth); }
        }

        public double Y
        {
            get { return Canvas.GetTop(_imageElement) / _sceneOptions.TileHeight; }
            set { Canvas.SetTop(_imageElement, value * _sceneOptions.TileHeight); }
        }
    }
}