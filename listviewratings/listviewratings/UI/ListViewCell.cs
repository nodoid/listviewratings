using listviewratings.CustomUI;
using listviewratings.Models;
using System.ComponentModel;
using Xamarin.Forms;

namespace listviewratings.UI
{
    public class ListViewCell : ViewCell
    {
        public ListViewCell()
        {
            var lblTitle = new Label
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 14,
                TextColor = Color.Blue,
            };
            lblTitle.SetBinding(Label.TextProperty, new Binding("Title"));

            var lblCategory = new Label
            {
                FontSize = 12,
                TextColor = Color.Green
            };
            lblCategory.SetBinding(Label.TextProperty, new Binding("Category"));

            var imgIcon = new Image
            {
                HeightRequest = 56,
                WidthRequest = 56
            };
            imgIcon.SetBinding(Image.SourceProperty, new Binding("ImageIcon"));

            var imgStar1 = new Image
            {
                WidthRequest = 24,
                HeightRequest = 24,
            };
            imgStar1.SetBinding(Image.SourceProperty, new Binding("StarRatings[0]"));

            var imgStar2 = new Image
            {
                WidthRequest = 24,
                HeightRequest = 24,
            };
            imgStar2.SetBinding(Image.SourceProperty, new Binding("StarRatings[1]"));

            var imgStar3 = new Image
            {
                WidthRequest = 24,
                HeightRequest = 24,
            };
            imgStar3.SetBinding(Image.SourceProperty, new Binding("StarRatings[2]"));

            var imgStar4 = new Image
            {
                WidthRequest = 24,
                HeightRequest = 24,
            };
            imgStar4.SetBinding(Image.SourceProperty, new Binding("StarRatings[3]"));

            var imgStar5 = new Image
            {
                WidthRequest = 24,
                HeightRequest = 24,
            };
            imgStar5.SetBinding(Image.SourceProperty, new Binding("StarRatings[4]"));

            var imgStar6 = new Image
            {
                WidthRequest = 24,
                HeightRequest = 24,
            };
            imgStar6.SetBinding(Image.SourceProperty, new Binding("StarRatings[5]"));

            var starStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(2, 0),
                Children = { imgStar1, imgStar2, imgStar3, imgStar4, imgStar5, imgStar6 }
            };
            starStack.SetBinding(StackLayout.ClassIdProperty, new Binding("Id"));

            var theStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(4),
                Children =
                {
                    imgIcon,
                    new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        Children = {lblTitle, starStack, lblCategory}
                    }
                }
            };

            var tapRecogniser = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1,
                Command = new Command(() =>
                {
                    App.Self.IdInUse = ((ListviewModel)BindingContext).Id;
                var cv = new ModalView
                {
                    IsClippedToBounds = true,
                    Rating = ((ListviewModel)BindingContext).CurrentRating,
                    };
                    theStack.Children.Add(cv);
                })
            };
            theStack.GestureRecognizers.Add(tapRecogniser);

            View = theStack;
        }
    }
}
