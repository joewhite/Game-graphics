using GameGraphics.Core;
using GameGraphics.WinFormsCommon;

namespace GameGraphics.WinFormsPictureBoxes
{
    public class PictureBoxController : IController
    {
        public string Description
        {
            get { return "PictureBoxes"; }
        }
        public Library Library
        {
            get { return Library.WinForms; }
        }

        public void Run(Scene scene, SceneOptions options)
        {
            using (var form = new GraphicsForm(scene))
            {
                var view = new PictureBoxView(options);
                scene.Initialize(view);
                form.SetView(view);
                form.ShowDialog();
            }
        }
    }
}