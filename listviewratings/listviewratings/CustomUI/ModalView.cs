﻿
using listviewratings.UI;
using Xamarin.Forms;

namespace listviewratings.CustomUI
{
    public class ModalView : ContentView
    {
        public static readonly BindableProperty RatingProperty = BindableProperty.Create(
    propertyName: "Rating",
    returnType: typeof(int),
    declaringType: typeof(ModalView),
    defaultValue: 0);

        public int Rating
        {
            get { return (int)GetValue(RatingProperty); }
            set { SetValue(RatingProperty, value); }
        }
    }
}
