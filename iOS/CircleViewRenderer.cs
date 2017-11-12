using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using CoreGraphics;
using UIKit;

using Sample;
using Sample.iOS;

[assembly: ExportRenderer(typeof(CircleView), typeof(CircleViewRenderer))]

namespace Sample.iOS
{
    public class CircleViewRenderer : ViewRenderer
    {
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            
            var context = UIGraphics.GetCurrentContext();
            
            context.SetFillColor(Color.Aqua.ToCGColor());
            context.FillEllipseInRect(rect);
        }
    }
}

