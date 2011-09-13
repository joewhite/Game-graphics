using System.Windows.Forms;
using GameGraphics.Core;

namespace GameGraphics.WinFormsPictureBoxes
{
    public class PictureBoxSprite : ISprite
    {
        private readonly PictureBox _control;
        private readonly SceneOptions _options;

        public PictureBoxSprite(PictureBox control, SceneOptions options)
        {
            _control = control;
            _options = options;
        }

        public double X
        {
            get { return (double)_control.Left / _options.TileWidth; }
            set { _control.Left = (int)(value * _options.TileWidth); }
        }
        public double Y
        {
            get { return (double)_control.Top / _options.TileHeight; }
            set { _control.Top = (int)(value * _options.TileHeight); }
        }
    }
}