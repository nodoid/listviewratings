using listviewratings.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace listviewratings.UI
{
    public class ListviewData : ContentPage
    {
        List<ListviewModel> dataList;

        public ListviewData()
        {
            SetupList();
            CreateUI();
        }

        void SetupList()
        {
            var icons = new List<string> { "cyber1", "cyber2", "who" };
            var titles = new List<string> { "Anxiety", "Depression", "Self-harm", "Solvent abuse", "Supporting Man U", "Domestic abuse",
                "Disaster", "Spousal abuse", "Wearing sandals", "Being a manc" };
            dataList = new List<ListviewModel>();
            var rnd = new Random();
            for(var n = 0; n < 10; ++n)
            {
                dataList.Add(new ListviewModel
                {
                    Title = string.Format("Test {0}", n),
                    ImageIcon = icons[rnd.Next(0, icons.Count)],
                    Category = titles[rnd.Next(0, titles.Count)],
                    CurrentRating = rnd.Next(0, 6),
                    StarRatings = new List<string>(),
                    Id = n
                });

                dataList[n].StarRatings = ConvertRatingToStars(dataList[n].CurrentRating);
            }
        }

        public static List<string> ConvertRatingToStars(int rating)
        {
            var ratingStars = new List<string>() { "emptystar", "emptystar", "emptystar", "emptystar", "emptystar", "emptystar" };
            if (rating == 0)
                return ratingStars;

            switch (rating)
            {
                case 1:
                    ratingStars[0] = "pinkstar";
                    break;
                case 2:
                    ratingStars[0] = "pinkstar";
                    ratingStars[1] = "purplestar";
                    break;
                case 3:
                    ratingStars[0] = "pinkstar";
                    ratingStars[1] = "purplestar";
                    ratingStars[2] = "greenstar";
                    break;
                case 4:
                    ratingStars[0] = "pinkstar";
                    ratingStars[1] = "purplestar";
                    ratingStars[2] = "greenstar";
                    ratingStars[3] = "bluestar";
                    break;
                case 5:
                    ratingStars[0] = "pinkstar";
                    ratingStars[1] = "purplestar";
                    ratingStars[2] = "greenstar";
                    ratingStars[3] = "bluestar";
                    ratingStars[4] = "yellowstar";
                    break;
                case 6:
                    ratingStars[0] = "pinkstar";
                    ratingStars[1] = "purplestar";
                    ratingStars[2] = "greenstar";
                    ratingStars[3] = "bluestar";
                    ratingStars[4] = "yellowstar";
                    ratingStars[5] = "orangestar";
                    break;
            }

            for (var i = rating; i < ratingStars.Count; ++i)
                ratingStars[i] = "emptystar";

            return ratingStars;
        }

        void CreateUI()
        {

            var datalist = new ListView
            {
                ItemsSource = dataList,
                ItemTemplate = new DataTemplate(typeof(ListViewCell)),
                HasUnevenRows = true,
                SeparatorVisibility = SeparatorVisibility.None
            };

            App.Self.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
            {
                if (e.PropertyName == "NewIconRating")
                {
                    var bc = dataList[App.Self.IdInUse];
                    bc.CurrentRating = App.Self.NewIconRating;
                    bc.StarRatings = ListviewData.ConvertRatingToStars(bc.CurrentRating);
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        datalist.ItemsSource = null;
                        datalist.ItemsSource = dataList;
                    });
                    }
            };

            Content = datalist;
        }
    }
}
