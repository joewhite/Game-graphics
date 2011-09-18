using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using GameGraphics.Core;

namespace GameGraphics.WpfMvvm
{
    public partial class MvvmView : IView
    {
        private readonly SceneOptions _options;
        private readonly ObservableCollection<MvvmSprite> _sprites = new ObservableCollection<MvvmSprite>();

        public MvvmView(SceneOptions options)
        {
            _options = options;
            InitializeComponent();
            DataContext = _sprites;
        }

        public ISprite CreateSprite(string imagePath)
        {
            var uri = new Uri(imagePath);
            var imageSource = new BitmapImage(uri);
            var sprite = new MvvmSprite(imageSource, _options);
            _sprites.Add(sprite);
            return sprite;
        }
        public void FrameCompleted()
        {
        }
    }
}