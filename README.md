This is my proof-of-concept on creating video games in .NET that don't require the user to install any other dependencies (no XNA framework, no requirement to download the latest DirectX, etc.) I used this code when presenting to the Omaha .NET User Group on 29 Sep 2011.

There's one common set of animation code (contained in the Scene class), and multiple different UI layers built on top of that common code. The goal was to see how performance compared across the different UI technologies, and find out:

1. whether it was practical to write a video game without XNA or DirectX; and
2. whether that game could run with relatively low CPU usage (and, therefore, good battery life).

Currently I have the following UI layers available. Most are in the GameGraphicsVS2010 solution, but since the Metro app is built on the prerelease Windows 8 developer preview and requires Visual Studio 2011, it's in a separate GameGraphics2011 solution.

* WinForms with PictureBoxes (one PictureBox control for each image onscreen). This is trivial, but suffers from the fact that WinForms controls can't do proper transparency.
* WinForms with custom paint.
* WPF with MVVM (model-view-viewmodel), i.e. databinding.
* WPF with Image elements, being moved manually in code.
* Silverlight with Image elements, being moved manually in code. (I haven't been able to get databinding to work with Silverlight yet, due to Silverlight's lack of ItemContainerStyle.)
* Metro (fullscreen Windows 8 app) using C#/XAML.