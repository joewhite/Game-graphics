using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
        private readonly IList<ControllerViewModel> _allControllerViewModels;
        private readonly IList<ResolutionViewModel> _allResolutionViewModels;
        private readonly ObservableCollection<RunResults> _runResults = new ObservableCollection<RunResults>();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += (sender, e) => ClearValue(SizeToContentProperty);

            _allControllerViewModels =
                (from type in GetType().Assembly.GetTypes()
                 where !type.IsInterface && typeof(IController).IsAssignableFrom(type)
                 let viewModel = new ControllerViewModel((IController)Activator.CreateInstance(type))
                 orderby viewModel.Library, viewModel.Description
                 select viewModel).ToList();
            _allControllerViewModels.First().IsChecked = true;
            ControllerGroups.ItemsSource = _allControllerViewModels.GroupBy(viewModel => viewModel.Library);

            _allResolutionViewModels = new[] {
                new ResolutionViewModel(800, 600, 50, 42),
                new ResolutionViewModel(1024, 768, 64, 54),
                new ResolutionViewModel(1280, 1024, 80, 73),
                new ResolutionViewModel(1440, 900, 90, 64),
            };
            _allResolutionViewModels.Last(
                res => res.Width <= SystemParameters.PrimaryScreenWidth &&
                res.Height <= SystemParameters.PrimaryScreenHeight).IsChecked = true;
            Resolutions.ItemsSource = _allResolutionViewModels;

            RunResults.ItemsSource = _runResults;
        }

        private void LogResults(IController controller, Scene scene)
        {
            var elapsed = scene.Elapsed;
            var fps = scene.FrameCount / elapsed.TotalSeconds;
            var results = new RunResults(
                controller.Library + " " + controller.Description,
                elapsed, fps, scene.CpuUsageSelf.Cpu, scene.CpuUsageDwm.Cpu);
            _runResults.Add(results);
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
            var controllerViewModel = _allControllerViewModels.First(vm => vm.IsChecked);
            var controller = controllerViewModel.Controller;

            var resolutionViewModel = _allResolutionViewModels.First(vm => vm.IsChecked);
            Run(controller, resolutionViewModel.DirectoryName, resolutionViewModel.TileWidth, resolutionViewModel.TileHeight);
        }
        private void Run(IController controller, string directoryName, int tileWidth, int tileHeight)
        {
            var exeDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var imageDirectory = Path.Combine(exeDirectory, "Images", directoryName);
            var options = new SceneOptions(imageDirectory, tileWidth, tileHeight);
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