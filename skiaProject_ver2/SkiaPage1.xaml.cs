using System;
using System.Collections.Generic;
using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace skiaProject_ver2
{
    public partial class SkiaPage1 : ContentPage
    {

        public SkiaPage1()
        {
            InitializeComponent();
        }


        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.Red.ToSKColor(),
                StrokeWidth = 25
            };

            int[,] rectList = new int[,] { { 100, 100, 100 }, { 200, 100, 100 }, { 300, 100, 100 }, { 400, 100, 100 } };
            int[] rect = new int[] { 100, 200, 300 };
            Console.WriteLine(rect[1]);
            for (int i = 0; i < rect.Length; i++)
            {
                //Console.WriteLine(rect[i]);
                canvas.DrawRect(info.Width / 10, rect[i], 100, 100, paint);
            }
            for (int i = 0; i < rectList.GetLength(0); i++)
            {
                //Console.WriteLine(rectList[i,1]);
                canvas.DrawRect(info.Width / 10, rectList[i, 0], rectList[i, 1], rectList[i, 2], paint);
            }

        }
    }
}