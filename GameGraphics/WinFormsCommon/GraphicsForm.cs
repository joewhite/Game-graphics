using System.Diagnostics;
using System.Windows.Forms;
using GameGraphics.Core;

namespace GameGraphics.WinFormsCommon
{
    public partial class GraphicsForm : Form
    {
        private readonly Scene _scene;
        private Stopwatch _stopwatch;

        public GraphicsForm(Scene scene)
        {
            _scene = scene;
            InitializeComponent();
            _stopwatch = new Stopwatch();
        }

        private void GraphicsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
        public void SetView(Control view)
        {
            view.Dock = DockStyle.Fill;
            Controls.Add(view);
        }
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            _scene.Update(_stopwatch.Elapsed);
            _stopwatch.Restart();
        }
    }
}