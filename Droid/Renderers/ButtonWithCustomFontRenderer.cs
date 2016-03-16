using System;
using Android.Graphics;
using FindMe.Droid.Renderers;
using FindMe.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ButtonWithCustomFont), typeof(ButtonWithCustomFontRenderer))]
namespace FindMe.Droid.Renderers
{
    public class ButtonWithCustomFontRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            try
            {
                var buttonWithCustomFont = e.NewElement;
                if (buttonWithCustomFont != null)
                {
                    var fontPath = buttonWithCustomFont.FontFamily;
                    var button = Control;
                    var font = Typeface.CreateFromAsset(Forms.Context.Assets, fontPath);
                    button.Typeface = font;
                }
            }
            catch (Exception)
            {
                // Ignore any errors (like font file was not found, etc.) and let XF render using default
            }
        }
    }
}