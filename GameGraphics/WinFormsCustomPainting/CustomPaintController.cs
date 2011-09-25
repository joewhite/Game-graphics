using GameGraphics.Core;
using GameGraphics.WinFormsCommon;

namespace GameGraphics.WinFormsCustomPainting
{
    public class CustomPaintController : IController
    {
        public string Description
        {
            get { return "Custom paint"; }
        }
        public Library Library
        {
            get { return Library.WinForms; }
        }
        public int SortIndex
        {
            get { return 20; }
        }

        public void Run(Scene scene, SceneOptions options)
        {
            using (var form = new GraphicsForm(scene))
            {
                var view = new CustomPaintView(options);
                scene.Initialize(view);
                form.SetView(view);
                form.ShowDialog();
            }
        }
    }
}