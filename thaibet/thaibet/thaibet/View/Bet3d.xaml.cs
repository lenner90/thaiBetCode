using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Newtonsoft.Json;

namespace thaibet.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Bet3d : ContentPage
	{
		public Bet3d ()
		{
			InitializeComponent ();
            #region
            //var layout = new StackLayout();
            //layout.Spacing = 5;
            //layout.HorizontalOptions = LayoutOptions.FillAndExpand;


            //var horStkLTitle = new StackLayout
            //{
            //    Orientation = StackOrientation.Horizontal,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    Spacing = 50
            //};

            //var lblNoTitle = new Label
            //{
            //    Text = "Number",
            //    HorizontalOptions = LayoutOptions.Center
            //};

            //var lblUpTitle = new Label
            //{
            //    Text = "Up",
            //    HorizontalOptions = LayoutOptions.Center
            //};

            //var lblDownTitle = new Label
            //{
            //    Text = "Down",
            //    HorizontalOptions = LayoutOptions.Center
            //};
            //horStkLTitle.Children.Add(lblNoTitle);
            //horStkLTitle.Children.Add(lblUpTitle);
            //horStkLTitle.Children.Add(lblDownTitle);

            //var horStkLitm1 = new StackLayout
            //{
            //    Orientation = StackOrientation.Horizontal,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    Spacing = 50
            //};

            //var lblNo1 = new Entry
            //{
            //    Text = "",
            //    HorizontalOptions = LayoutOptions.Center,
            //    MaxLength=4
            //};

            //var lblUp1= new Entry
            //{
            //    Text = "",
            //    HorizontalOptions = LayoutOptions.Center
            //};

            //var lblDown1 = new Entry
            //{
            //    Text = "",
            //    HorizontalOptions = LayoutOptions.Center
            //};
            //horStkLitm1.Children.Add(lblNo1);
            //horStkLitm1.Children.Add(lblUp1);
            //horStkLitm1.Children.Add(lblDown1);

            //layout.Children.Add(horStkLTitle);
            //layout.Children.Add(horStkLitm1);
            //Content = layout;
            #endregion
        }

        async void OnClicked(object o, EventArgs e)
        {
            string batchId = string.Empty;
            string urlPath = Application.Current.Properties["ApiUrl"].ToString() + "/GetUid";
            var request = HttpWebRequest.Create(urlPath);
            request.ContentType = "application/json";
            request.Method = "GET";
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
                        batchId = content.ToString().Replace("\"","");
                    }


                }
            }

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Application.Current.Properties["ApiUrl"].ToString() + "/InsertBet");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                List<betObject> betList = new List<betObject>();
                if (!string.IsNullOrEmpty(txtNo1.Text))
                {
                    betObject betItem = new betObject();
                    betItem.batch_id = batchId;
                    betItem.agent_id = int.Parse(Application.Current.Properties["userId"].ToString());
                    betItem.bet_type = "3D";
                    betItem.bet_number = int.Parse(txtNo1.Text);
                    betItem.up = int.Parse(txtUp1.Text);
                    betItem.down = int.Parse(txtDown1.Text);
                    betItem.created_date = DateTime.Now;
                    betItem.created_by = int.Parse(Application.Current.Properties["userId"].ToString());
                    betItem.updated_date = DateTime.Now;
                    betItem.updated_by = int.Parse(Application.Current.Properties["userId"].ToString());
                    betList.Add(betItem);
                }
                if (!string.IsNullOrEmpty(txtNo2.Text))
                {
                    betObject betItem = new betObject();
                    betItem.batch_id = batchId;
                    betItem.agent_id = int.Parse(Application.Current.Properties["userId"].ToString());
                    betItem.bet_type = "3D";
                    betItem.bet_number = int.Parse(txtNo2.Text);
                    betItem.up = int.Parse(txtUp2.Text);
                    betItem.down = int.Parse(txtDown2.Text);
                    betItem.created_date = DateTime.Now;
                    betItem.created_by = int.Parse(Application.Current.Properties["userId"].ToString());
                    betItem.updated_date = DateTime.Now;
                    betItem.updated_by = int.Parse(Application.Current.Properties["userId"].ToString());
                    betList.Add(betItem);
                }
                if (!string.IsNullOrEmpty(txtNo3.Text))
                {
                    betObject betItem = new betObject();
                    betItem.batch_id = batchId;
                    betItem.agent_id = int.Parse(Application.Current.Properties["userId"].ToString());
                    betItem.bet_type = "3D";
                    betItem.bet_number = int.Parse(txtNo3.Text);
                    betItem.up = int.Parse(txtUp3.Text);
                    betItem.down = int.Parse(txtDown3.Text);
                    betItem.created_date = DateTime.Now;
                    betItem.created_by = int.Parse(Application.Current.Properties["userId"].ToString());
                    betItem.updated_date = DateTime.Now;
                    betItem.updated_by = int.Parse(Application.Current.Properties["userId"].ToString());
                    betList.Add(betItem);
                }
                if (!string.IsNullOrEmpty(txtNo4.Text))
                {
                    betObject betItem = new betObject();
                    betItem.batch_id = batchId;
                    betItem.agent_id = int.Parse(Application.Current.Properties["userId"].ToString());
                    betItem.bet_type = "3D";
                    betItem.bet_number = int.Parse(txtNo4.Text);
                    betItem.up = int.Parse(txtUp4.Text);
                    betItem.down = int.Parse(txtDown4.Text);
                    betItem.created_date = DateTime.Now;
                    betItem.created_by = int.Parse(Application.Current.Properties["userId"].ToString());
                    betItem.updated_date = DateTime.Now;
                    betItem.updated_by = int.Parse(Application.Current.Properties["userId"].ToString());
                    betList.Add(betItem);
                }

                string json = JsonConvert.SerializeObject(betList);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //var result = streamReader.ReadToEnd();
                await Application.Current.MainPage.DisplayAlert("Alert", "Your have been Submit Successful", "OK");
                Application.Current.Properties["currBetList"] = batchId;
                Navigation.PushAsync(new receipt() { Title = "List" });
            }
        }
    }
}