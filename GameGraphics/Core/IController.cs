namespace GameGraphics.Core
{
    public interface IController
    {
        string Description { get; }
        Library Library { get; }

        void Run(Scene scene, SceneOptions options);
    }
}