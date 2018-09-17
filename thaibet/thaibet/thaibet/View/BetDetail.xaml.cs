using Newtonsoft.Json;
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
	public partial class BetDetail : ContentPage
	{
		public BetDetail ()
		{
			InitializeComponent ();

            betObject item = new betObject();

            string data = "?id=" + Application.Current.Properties["currBetId"].ToString();
            string urlPath = Application.Current.Properties["ApiUrl"].ToString() + "/GetBetListById";
            var request = HttpWebRequest.Create(urlPath + data);
            request.ContentType = "application/json";
            request.Method = "GET";
            //request.Method = "POST";
            request.ContentLength = 0;

            #region 
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    try
                    {
                        string content = reader.ReadToEnd();
                        var result = JsonConvert.DeserializeObject<betObject>(content);                            
                            item.id = result.id;
                            item.agent_id = result.agent_id;
                            item.bet_type = result.bet_type;
                            item.bet_number = result.bet_number;
                            item.up = result.up;
                            item.down = result.down;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
            }
            #endregion

            txtNumber.Text = item.bet_number.ToString();
            txtUp.Text = item.up.ToString();
            txtDown.Text = item.down.ToString();

        }

        async void OnClickedEdit(object o, EventArgs e)
        {
            betObject betItem = new betObject();

            string data = "?id=" + Application.Current.Properties["currBetId"] + "&num=" + txtNumber.Text + "&up=" + txtUp.Text + "&down=" + txtDown.Text;
            string urlPath = Application.Current.Properties["ApiUrl"].ToString() + "/UpdateBet";
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

        async void OnClickedDelete(object o, EventArgs e)
        {
            string data = "?id=" + Application.Current.Properties["currBetId"] ;
            string urlPath = Application.Current.Properties["ApiUrl"].ToString() + "/Delete";
            var request = HttpWebRequest.Create(urlPath + data);
            request.ContentType = "application/json";
            //request.Method = "GET";
            request.Method = "DELETE";
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
                        await Application.Current.MainPage.DisplayAlert("Alert", "Record Deleted Successful", "OK");
                    }


                }
            }
        }
    }
}