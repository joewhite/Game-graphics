using System.Drawing;
using GameGraphics.Core;

namespace GameGraphics.WinFormsCustomPainting
{
    public class CustomPaintSprite : ISprite
    {
        public CustomPaintSprite(Image image)
        {
            Image = image;
        }

        public Image Image { get; private set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
}