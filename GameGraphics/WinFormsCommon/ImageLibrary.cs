using System.Collections.Generic;
using System.Drawing;

namespace GameGraphics.WinFormsCommon
{
    public class ImageLibrary
    {
        private IDictionary<string, Image> _cache = new Dictionary<string, Image>();

        public Image GetImage(string imagePath)
        {
            Image image;
            if (_cache.TryGetValue(imagePath, out image))
                return image;
            return _cache[imagePath] = Image.FromFile(imagePath);
        }
    }
}