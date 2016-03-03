using System;
using System.ComponentModel;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using FindMe.iOS.Renderers;
using FindMe.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LineEntry), typeof(LineEntryRenderer))]
namespace FindMe.iOS.Renderers
{
    public class LineEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;

                var view = (Element as LineEntry);
                if (view != null)
                {
                    DrawBorder(view);
                    SetFontFamilyAndSize(view);
                    SetPlaceholderTextColor(view);
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var view = (LineEntry)Element;

            switch (e.PropertyName)
            {
                case "BorderColor":
                    DrawBorder(view);
                    break;
                case "FontFamily":
                case "FontSize":
                    SetFontFamilyAndSize(view);
                    break;
                case "PlaceholderColor":
                    SetPlaceholderTextColor(view);
                    break;
            }
        }

        private void DrawBorder(LineEntry view)
        {
            var borderLayer = new CALayer
                {
                    MasksToBounds = true,
                    Frame = new CGRect(0f, Frame.Height/2, Frame.Width, 1f),
                    BorderColor = view.BorderColor.ToCGColor(),
                    BorderWidth = 1.0f
                };

            Control.Layer.AddSublayer(borderLayer);
            Control.BorderStyle = UITextBorderStyle.None;
        }

        private void SetFontFamilyAndSize(LineEntry view)
        {
            var fontSize = view.FontSize > 0 ? (nfloat)view.FontSize : UIFont.SystemFontSize;
            var fontFamily = string.IsNullOrEmpty(view.FontFamily) ? UIFont.SystemFontOfSize(fontSize).FamilyName : view.FontFamily;
            Control.Font = UIFont.FromName(fontFamily, fontSize);
        }

        private void SetPlaceholderTextColor(LineEntry view)
        {
            if (!string.IsNullOrEmpty(view.Placeholder) && view.PlaceholderColor != Color.Default)
            {
                var placeholderString = new NSAttributedString(view.Placeholder, 
                    new UIStringAttributes { ForegroundColor = view.PlaceholderColor.ToUIColor() });

                Control.AttributedPlaceholder = placeholderString;
            }
        }
    }
}