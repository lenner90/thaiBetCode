using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using thaibet.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace thaibet.Login
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public void OnClicked(object o, EventArgs e)
        {
            bool isValid = false;
            UserAuthenticated();

            var nameValue = userNm.Text;
        }

        private void UserAuthenticated()
        {
            //string id = Application.Current.Properties["id"].ToString();

            string data = "?userName=" + userNm.Text + "&pass=" + txtPass.Text;
            string urlPath = Application.Current.Properties["ApiUrl"].ToString() +"/LoginUser";
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
                        lblMsg.Text = "Server under maintenance. Please try later";
                        lblMsg.IsVisible = true;
                    }
                    else
                    {
                        Console.Out.WriteLine("Response Body: \r\n {0}", content);
                        if (string.Equals(content, "0"))
                        {
                            lblMsg.Text = "Invalid credentials entered";
                            lblMsg.IsVisible = true;
                        }
                        else
                        {
                            Application.Current.Properties["userId"] = content.ToString();
                            Application.Current.Properties["userName"] = userNm.Text.Trim();
                            Navigation.PushAsync(new action());
                        }
                    }


                }
            }

        }
    }
}