using listviewratings.UI;

using Xamarin.Forms;

namespace listviewratings
{
    public class App : Application
    {
        public static Size ScreenSize { get; set; }
        public static App Self { get; private set; }

        int newIconRating;
        public int NewIconRating
        {
            get { return newIconRating; }
            set
            {
                newIconRating = value;
                OnPropertyChanged("NewIconRating");
            }
        }

        public int IdInUse { get; set; }

        public App()
        {
            App.Self = this;
            MainPage = new NavigationPage(new ListviewData());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
