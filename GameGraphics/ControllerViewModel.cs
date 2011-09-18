using GameGraphics.Core;

namespace GameGraphics
{
    public class ControllerViewModel
    {
        public ControllerViewModel(IController controller)
        {
            Controller = controller;
        }

        public IController Controller { get; private set; }
        public string Description
        {
            get { return Controller.Description; }
        }
        public bool IsChecked { get; set; }
        public Library Library
        {
            get { return Controller.Library; }
        }
    }
}