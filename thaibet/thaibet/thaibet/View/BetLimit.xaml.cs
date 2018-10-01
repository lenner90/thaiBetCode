using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace thaibet.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BetLimit : ContentPage
	{
		public BetLimit ()
		{
			InitializeComponent ();

            string data = "?code=bet_limit";
            string urlPath = Application.Current.Properties["ApiUrl"].ToString() + "/GetSetting";
            var request = HttpWebRequest.Create(urlPath + data);
            request.ContentType = "application/json";
            request.Method = "GET";
            request.ContentLength = 0;
            string betlimit = string.Empty;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    if (string.IsNullOrWhiteSpace(content))
                    {
                        Console.Out.WriteLine("Response contained empty body...");
                    }
                    else
                    {
                        betlimit = content.ToString().Replace("\"", "");
                        txtBetLimit.Text = betlimit;
                    }


                }
            }
        }

        async void OnClicked(object o, EventArgs e)
        {
            string data = "?code=bet_limit&value=" + txtBetLimit.Text;
            string urlPath = Application.Current.Properties["ApiUrl"].ToString() + "/UpdateSetting";
            var request = HttpWebRequest.Create(urlPath + data);
            request.ContentType = "application/json";
            //request.Method = "GET";
            request.Method = "POST";
            request.ContentLength = 0;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    if (string.IsNullOrWhiteSpace(content))
                    {
                        Console.Out.WriteLine("Response contained empty body...");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Alert", "Record Submit Successful", "OK");
                    }


                }
            }
        }

        public void OnTextChange(object sender, TextChangedEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(args.NewTextValue))
            {
                bool isValid = args.NewTextValue.ToCharArray().All(x => char.IsDigit(x)); //Make sure all characters are numbers

                ((Entry)sender).Text = isValid ? args.NewTextValue : args.NewTextValue.Remove(args.NewTextValue.Length - 1);
            }
        }
    }
}