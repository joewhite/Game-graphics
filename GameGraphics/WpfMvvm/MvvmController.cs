using GameGraphics.Core;
using GameGraphics.WpfCommon;

namespace GameGraphics.WpfMvvm
{
    public class MvvmController : IController
    {
        public string Description
        {
            get { return "MVVM"; }
        }
        public Library Library
        {
            get { return Library.Wpf; }
        }

        public void Run(Scene scene, SceneOptions options)
        {
            var window = new GraphicsWindow(scene);
            var view = new MvvmView(options);
            scene.Initialize(view);
            window.Content = view;
            window.ShowDialog();
        }
    }
}