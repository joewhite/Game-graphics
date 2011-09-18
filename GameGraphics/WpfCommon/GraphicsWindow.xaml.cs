using System;
using System.Windows.Input;
using System.Windows.Media;
using GameGraphics.Core;

namespace GameGraphics.WpfCommon
{
    public partial class GraphicsWindow
    {
        private TimeSpan? _lastRenderingTime;
        private readonly Scene _scene;

        public GraphicsWindow(Scene scene)
        {
            _scene = scene;
            InitializeComponent();
            Loaded += (sender, e) => CompositionTarget.Rendering += CompositionTarget_Rendering;
            Unloaded += (sender, e) => CompositionTarget.Rendering -= CompositionTarget_Rendering;
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            var args = (RenderingEventArgs)e;
            var elapsed = args.RenderingTime - (_lastRenderingTime ?? args.RenderingTime);
            _lastRenderingTime = args.RenderingTime;
            _scene.Update(elapsed);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Key == Key.Escape)
            {
                e.Handled = true;
                Close();
            }
        }
    }
}