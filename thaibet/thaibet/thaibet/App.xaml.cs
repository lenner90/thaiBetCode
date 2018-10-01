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
            Application.Current.Properties["ApiUrl"] = "http://203.115.216.251/BETAPI/BET";
            //http://203.115.216.251/APISIG/api/Values
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
