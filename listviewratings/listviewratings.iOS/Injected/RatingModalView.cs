using listviewratings.iOS.Injected;
using listviewratings.CustomUI;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;

[assembly: ExportRenderer(typeof(ModalView), typeof(RatingModalView))]
namespace listviewratings.iOS.Injected
{
    public class RatingModalView : ViewRenderer<ModalView, UIView>
    {
        int initialRating { get; set; }

        protected override void OnElementChanged(ElementChangedEventArgs<ModalView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var dialog = e.NewElement;

                CreateDialog(dialog);
            }
        }

        public void CreateDialog(ModalView dialog)
        {
            var view = new UIView(new CGRect(8, 32, AppDelegate.Self.ScreenX, 140));
            view = UICreation.MakePrettyView(view);

            var lblTitle = new UILabel(new CGRect(40, 4, 180, 24))
            {
                Text = "Time of death results",
            };
            view.Add(lblTitle);



            UIApplication.SharedApplication.KeyWindow.RootViewController.Add(view);
        }

    }
}