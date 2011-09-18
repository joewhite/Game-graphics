using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GameGraphics.Core;
using GameGraphics.WinFormsCommon;

namespace GameGraphics.WinFormsCustomPainting
{
    public partial class CustomPaintView : UserControl, IView
    {
        private ImageLibrary _imageLibrary = new ImageLibrary();
        private SceneOptions _options;
        private IList<CustomPaintSprite> _sprites = new List<CustomPaintSprite>();

        public CustomPaintView(SceneOptions options)
        {
            _options = options;
            InitializeComponent();
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.Opaque |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint,
                true);
            SetStyle(
                ControlStyles.ContainerControl |
                ControlStyles.SupportsTransparentBackColor,
                false);
        }

        public ISprite CreateSprite(string imagePath)
        {
            var image = _imageLibrary.GetImage(imagePath);
            var sprite = new CustomPaintSprite(image);
            _sprites.Add(sprite);
            return sprite;
        }
        public void FrameCompleted()
        {
            Refresh();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (var sprite in _sprites)
            {
                var x = (int)Math.Round(sprite.X * _options.TileWidth);
                var y = (int)Math.Round(sprite.Y * _options.TileHeight);
                e.Graphics.DrawImage(sprite.Image, new Point(x, y));
            }
        }
    }
}