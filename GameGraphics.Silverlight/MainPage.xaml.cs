using System;
using System.Windows.Media;
using GameGraphics.Core;
using GameGraphics.WpfElements;

namespace GameGraphics.Silverlight
{
    public partial class MainPage
    {
        private TimeSpan? _lastRenderingTime;
        private readonly Scene _scene;

        public MainPage()
        {
            InitializeComponent();
            var sceneOptions = new SceneOptions("/Images/800x600", 50, 42);
            _scene = new Scene(sceneOptions);
            var view = new ElementView(sceneOptions);
            _scene.Initialize(view);
            LayoutRoot.Children.Add(view);
            CompositionTarget.Rendering += new System.EventHandler(CompositionTarget_Rendering);
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            var args = (RenderingEventArgs)e;
            var elapsed = args.RenderingTime - (_lastRenderingTime ?? args.RenderingTime);
            _lastRenderingTime = args.RenderingTime;
            _scene.Update(elapsed);
        }
    }
}
