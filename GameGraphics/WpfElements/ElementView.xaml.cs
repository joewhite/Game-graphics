﻿using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using GameGraphics.Core;

namespace GameGraphics.WpfElements
{
    public partial class ElementView : IView
    {
        private readonly SceneOptions _sceneOptions;

        public ElementView(SceneOptions sceneOptions)
        {
            _sceneOptions = sceneOptions;
            InitializeComponent();
        }

        public ISprite CreateSprite(string imagePath)
        {
            var uri = new Uri(imagePath);
            var imageSource = new BitmapImage(uri);
            var image = new Image { Source = imageSource };
            var sprite = new ElementSprite(image, _sceneOptions);
            Canvas.Children.Add(image);
            return sprite;
        }
        public void FrameCompleted()
        {
        }
    }
}