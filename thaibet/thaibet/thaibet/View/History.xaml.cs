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
	public partial class History : ContentPage
	{
        List<betObject> betList = new List<betObject>();
		public History ()
		{
            string data = "?type=" + "3D" + "&id=" + Application.Current.Properties["userId"].ToString();
            string urlPath = Application.Current.Properties["ApiUrl"].ToString() + "/GetBetList";
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
                        var result = JsonConvert.DeserializeObject<List<betObject>>(content);
                        //Application.Current.Properties["itemCartList"] = content;
                        foreach (var itm in result)
                        {
                            betObject item = new betObject();
                            item.id = itm.id;
                            item.agent_id = itm.agent_id;
                            item.bet_type = itm.bet_type;
                            item.bet_number = itm.bet_number;
                            item.up = itm.up;
                            item.down = itm.down;
   
                            betList.Add(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
            }
            #endregion

            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.NumberOfTapsRequired = 2;
            // NumberOfTapsRequired="2"
            tap.Tapped += (sender, e) =>
            {
                Label TappedStackId = sender as Label;
                string id = TappedStackId.ClassId;
                Application.Current.Properties["currBetId"] = id;
                Navigation.PushAsync(new BetDetail() { Title = "Detail" });               
            };

            Grid grd = new Grid
            {
                // VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                //    //Width = new GridLength(0.35, GridUnitType.Star)
                    new RowDefinition { Height = GridLength.Star } //new GridLength(0.2, GridUnitType.Star) }
                //   // new RowDefinition { Height = new GridLength(0.10, GridUnitType.Star)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) }
                }
            };
           // grd.GestureRecognizers.Add(tap);
            var scroll = new ScrollView();

            var stkL = new StackLayout
            {
                Orientation = StackOrientation.Vertical
            };

            int row = 0;
            int itmCount = 1;
            //int col = 0;
            foreach (var itm in betList)
            {
                var horStkL = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal
                };

                var lblNo = new Label
                {
                    Text = itmCount.ToString(),
                    ClassId = itm.id.ToString()
                };
                lblNo.GestureRecognizers.Add(tap);

                var lblNumber = new Label
                {
                    Text = itm.bet_number.ToString(),
                    ClassId = itm.id.ToString()
                };
                lblNumber.GestureRecognizers.Add(tap);

                var lblUp = new Label
                {
                    Text = itm.up.ToString(),
                    ClassId = itm.id.ToString()
                };
                lblUp.GestureRecognizers.Add(tap);

                var lblDown = new Label
                {
                    Text = itm.down.ToString(),
                    ClassId = itm.id.ToString()
                };
                lblDown.GestureRecognizers.Add(tap);

                //horStkL.Children.Add(lblNo);
                //horStkL.Children.Add(lblNumber);
                //horStkL.Children.Add(lblUp);
                //horStkL.Children.Add(lblDown);
                // stkL.Children.Add(horStkL);

                grd.Children.Add(lblNo, 0, row);
                grd.Children.Add(lblNumber, 1, row);
                grd.Children.Add(lblUp, 2, row);
                grd.Children.Add(lblDown, 3, row);
                row++;
                itmCount++;
            }

            grd.Children.Add(stkL, 0, 0);
      
            Content = new ScrollView
            {
                Orientation = ScrollOrientation.Vertical,
                Content = grd
            };
            InitializeComponent();
		}
	}
}