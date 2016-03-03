using Foundation;
using FindMe.iOS.Renderers;
using FindMe.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PageKeyboardAware), typeof(PageKeyboardAwareRenderer))]
namespace FindMe.iOS.Renderers
{
    public class PageKeyboardAwareRenderer : PageRenderer
    {
        private NSObject _observerHideKeyboard;
        private NSObject _observerShowKeyboard;

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            _observerHideKeyboard = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, OnKeyboardNotification);
            _observerShowKeyboard = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, OnKeyboardNotification);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            NSNotificationCenter.DefaultCenter.RemoveObserver(_observerHideKeyboard);
            NSNotificationCenter.DefaultCenter.RemoveObserver(_observerShowKeyboard);
        }

        private void OnKeyboardNotification(NSNotification notification)
        {
            if (!IsViewLoaded) return;

            var frameBegin = UIKeyboard.FrameBeginFromNotification(notification);
            var frameEnd = UIKeyboard.FrameEndFromNotification(notification);
            var bounds = Element.Bounds;
            var newBounds = new Rectangle(bounds.Left, bounds.Top, bounds.Width,
                bounds.Height - frameBegin.Top + frameEnd.Top);

            Element.Layout(newBounds);
        }
    }
}

