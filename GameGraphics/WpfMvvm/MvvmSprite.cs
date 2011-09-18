using System.ComponentModel;
using System.Windows.Media;
using GameGraphics.Core;

namespace GameGraphics.WpfMvvm
{
    public class MvvmSprite : INotifyPropertyChanged, ISprite
    {
        private readonly SceneOptions _options;
        private double _x;
        private double _y;

        public MvvmSprite(ImageSource imageSource, SceneOptions options)
        {
            ImageSource = imageSource;
            _options = options;
        }

        public double Left
        {
            get { return _x * _options.TileWidth; }
        }
        public ImageSource ImageSource { get; private set; }
        public double Top
        {
            get { return _y * _options.TileHeight; }
        }
        public double X
        {
            get { return _x; }
            set
            {
                if (_x == value)
                    return;
                _x = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("X"));
                    PropertyChanged(this, new PropertyChangedEventArgs("Left"));
                }
            }
        }
        public double Y
        {
            get { return _y; }
            set
            {
                if (_y == value)
                    return;
                _y = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Y"));
                    PropertyChanged(this, new PropertyChangedEventArgs("Top"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}