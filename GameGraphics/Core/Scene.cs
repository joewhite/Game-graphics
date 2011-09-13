using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace GameGraphics.Core
{
    public class Scene
    {
        private double? _initialProcessorTime;
        private readonly SceneOptions _options;
        private double _position;
        private Stopwatch _runTime = new Stopwatch();
        private List<ISprite> _sprites = new List<ISprite>();

        public Scene(SceneOptions options)
        {
            _options = options;
        }

        public double CurrentProcessorTime
        {
            get { return Process.GetCurrentProcess().TotalProcessorTime.TotalSeconds / Environment.ProcessorCount; }
        }
        public TimeSpan Elapsed
        {
            get { return _runTime.Elapsed; }
        }
        public int FrameCount { get; private set; }
        public double InitialProcessorTime
        {
            get { return _initialProcessorTime ?? 0; }
        }
        public IView View { get; private set; }

        public void Initialize(IView view)
        {
            View = view;
            _sprites.Add(View.CreateSprite(Path.Combine(_options.ImageDirectory, "hero.png")));
            for (var index = 0; index < 19; ++index)
                _sprites.Add(View.CreateSprite(Path.Combine(_options.ImageDirectory, "enemy.png")));
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
            if (_initialProcessorTime == null)
                _initialProcessorTime = CurrentProcessorTime;
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
        }
    }
}