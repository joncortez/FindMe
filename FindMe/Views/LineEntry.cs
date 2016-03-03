using Xamarin.Forms;

namespace FindMe.Views
{
    public class LineEntry : Entry
    {
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create<LineEntry, Color>(p => p.BorderColor, Color.Black);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

//        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create<LineEntry, double>(p => p.FontSize, Font.Default.FontSize);
//
//        public double FontSize
//        {
//            get { return (double)GetValue(FontSizeProperty); }
//            set { SetValue(FontSizeProperty, value); }
//        }
//
//        public static readonly BindableProperty PlaceholderColorProperty =
//            BindableProperty.Create<LineEntry, Color>(p => p.PlaceholderColor, Color.Default);
//
//        public Color PlaceholderColor
//        {
//            get { return (Color)GetValue(PlaceholderColorProperty); }
//            set { SetValue(PlaceholderColorProperty, value); }
//        }
//
//        public static readonly BindableProperty FontFamilyProperty =
//            BindableProperty.Create<LineEntry, string>(p => p.FontFamily, Font.Default.FontFamily);
//
//        public string FontFamily
//        {
//            get { return (string) GetValue(FontFamilyProperty); }
//            set { SetValue(FontFamilyProperty, value); }
//        }
    }
}

