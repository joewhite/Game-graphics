using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace GameGraphics.Core
{
    public class Scene
    {
        private readonly SceneOptions _options;
        private double _position;
        private Stopwatch _runTime = new Stopwatch();
        private List<ISprite> _sprites = new List<ISprite>();

        public Scene(SceneOptions options)
        {
            _options = options;
            CpuUsageSelf = new ProcessCpuUsage(Process.GetCurrentProcess());
            CpuUsageDwm = new ProcessCpuUsage(Process.GetProcessesByName("dwm").FirstOrDefault());
        }

        public ProcessCpuUsage CpuUsageDwm { get; private set; }
        public ProcessCpuUsage CpuUsageSelf { get; private set; }
        public TimeSpan Elapsed
        {
            get { return _runTime.Elapsed; }
        }
        public int FrameCount { get; private set; }
        public IView View { get; private set; }

        private ISprite CreateSprite(string fileName, double x = 0, double y = 0)
        {
            var sprite = View.CreateSprite(Path.Combine(_options.ImageDirectory, fileName));
            sprite.X = x;
            sprite.Y = y;
            return sprite;
        }
        public void Initialize(IView view)
        {
            View = view;
            for (var y = 0; y < 14; ++y)
            {
                for (var x = 0; x < 16; ++x)
                    CreateSprite("BackgroundTile.bmp", x, y);
            }
            CreateSprite("TopLeft.png", 0, 0);
            CreateSprite("TopRight.png", 15, 0);
            CreateSprite("BottomLeft.png", 0, 13);
            CreateSprite("BottomRight.png", 15, 13);
            for (var x = 1; x <= 14; ++x)
            {
                CreateSprite("Horizontal.png", x, 0);
                CreateSprite("Horizontal.png", x, 13);
            }
            for (var y = 1; y <= 12; ++y)
            {
                CreateSprite("Vertical.png", 0, y);
                CreateSprite("Vertical.png", 15, y);
            }
            for (var y = 1; y <= 12; ++y)
            {
                for (var x = 1; x <= 14; ++x)
                    CreateSprite("Dot.png", x, y);
            }
            _sprites.Add(CreateSprite("Hero.png"));
            for (var index = 0; index < 19; ++index)
                _sprites.Add(CreateSprite("Enemy.png"));
        }
        private void SetSpritePosition(ISprite sprite, double position)
        {
            position = ((position % 48) + 48) % 48;
            if (position < 13)
            {
                sprite.X = position + 1;
                sprite.Y = 1;
                return;
            }
            position -= 13;
            if (position < 11)
            {
                sprite.X = 14;
                sprite.Y = position + 1;
                return;
            }
            position -= 11;
            if (position < 13)
            {
                sprite.X = 14 - position;
                sprite.Y = 12;
                return;
            }
            position -= 13;
            sprite.X = 1;
            sprite.Y = 12 - position;
        }
        public void Update(TimeSpan elapsed)
        {
            _runTime.Start();
            CpuUsageSelf.Initialize();
            CpuUsageDwm.Initialize();
            ++FrameCount;

            _position += elapsed.TotalSeconds * 3;
            var spritePosition = _position;
            var delta = 2.0;
            foreach (var sprite in _sprites)
            {
                SetSpritePosition(sprite, spritePosition);
                spritePosition -= delta;
                delta = 1;
            }
            View.FrameCompleted();
        }
    }
}