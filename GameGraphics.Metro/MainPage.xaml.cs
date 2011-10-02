using System;
using Windows.UI.Xaml.Media;
using GameGraphics.Core;
using GameGraphics.WpfElements;

namespace GameGraphics.Metro
{
    partial class MainPage
    {
        private TimeSpan? _lastRenderingTime;
        private readonly Scene _scene;

        public MainPage()
        {
            InitializeComponent();
            new Uri("pack://application,,,/Images/800x600/BackgroundTile.bmp");
            var sceneOptions = new SceneOptions("ms-resource://MyAssembly/Images/800x600", 50, 42);
            _scene = new Scene(sceneOptions);
            var view = new ElementView(sceneOptions);
            _scene.Initialize(view);
            LayoutRoot.Children.Add(view);
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        void CompositionTarget_Rendering(object sender, object e)
        {
            var args = (RenderingEventArgs)e;
            var elapsed = args.RenderingTime - (_lastRenderingTime ?? args.RenderingTime);
            _lastRenderingTime = args.RenderingTime;
            _scene.Update(elapsed);
        }
    }
}