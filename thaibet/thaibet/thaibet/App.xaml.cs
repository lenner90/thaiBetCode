using System;
using thaibet.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace thaibet
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
            //MainPage = new MainPage();
        }

		protected override void OnStart ()
		{
            // Handle when your app starts
            Application.Current.Properties["ApiUrl"] = "http://192.168.0.173/BETAPI/BET";
        }

        protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
