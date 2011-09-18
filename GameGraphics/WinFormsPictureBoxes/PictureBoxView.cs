using System.Drawing;
using System.Windows.Forms;
using GameGraphics.Core;

namespace GameGraphics.WinFormsPictureBoxes
{
    public partial class PictureBoxView : UserControl, IView
    {
        private readonly SceneOptions _options;

        public PictureBoxView(SceneOptions options)
        {
            _options = options;
            InitializeComponent();
        }

        public ISprite CreateSprite(string imagePath)
        {
            var image = Image.FromFile(imagePath);
            var pictureBox = new PictureBox { Image = image, Width = _options.TileWidth, Height = _options.TileHeight };
            Controls.Add(pictureBox);
            Controls.SetChildIndex(pictureBox, 0);
            return new PictureBoxSprite(pictureBox, _options);
        }
        public void FrameCompleted()
        {
        }
    }
}