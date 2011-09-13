using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using GameGraphics.Core;
using GameGraphics.WinFormsCommon;
using GameGraphics.WinFormsPictureBoxes;

namespace GameGraphics
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (sender, e) => ClearValue(SizeToContentProperty);
        }

        private void LogResults(IController controller, Scene scene)
        {
            var elapsed = scene.Elapsed;
            var fps = scene.FrameCount / elapsed.TotalSeconds;
            var cpu = (scene.CurrentProcessorTime - scene.InitialProcessorTime) / elapsed.TotalSeconds * 100;
            var status = string.Format("{0} {1} ({2:n1}s): {3:n1} fps, {4:n1}% CPU",
                controller.Library, controller.Description, elapsed.TotalSeconds, fps, cpu);
            var text = Log.Text;
            if (!string.IsNullOrEmpty(text))
                text += Environment.NewLine;
            text += status;
            Log.Text = text;
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Key == Key.Escape)
                Close();
            if (e.Key == Key.F5)
                Run();
        }
        private void Run()
        {
            var controller = new PictureBoxController();
            Run(controller);
        }
        private void Run(IController controller)
        {
            var exeDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var imageDirectory = Path.Combine(exeDirectory, "Images", "1440x900");
            var options = new SceneOptions(imageDirectory, 90, 64);
            var scene = new Scene(options);
            controller.Run(scene, options);
            LogResults(controller, scene);
        }
        private void RunClick(object sender, RoutedEventArgs e)
        {
            Run();
        }
    }
}