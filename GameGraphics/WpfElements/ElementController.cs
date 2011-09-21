using GameGraphics.Core;
using GameGraphics.WpfCommon;

namespace GameGraphics.WpfElements
{
    public class ElementController : IController
    {
        public string Description
        {
            get { return "Elements"; }
        }
        public Library Library
        {
            get { return Library.Wpf; }
        }

        public void Run(Scene scene, SceneOptions options)
        {
            var window = new GraphicsWindow(scene);
            var view = new ElementView(options);
            scene.Initialize(view);
            window.Content = view;
            window.ShowDialog();
        }
    }
}