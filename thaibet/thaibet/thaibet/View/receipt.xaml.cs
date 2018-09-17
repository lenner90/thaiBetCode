using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class receipt : ContentPage
    {
        List<betObject> betList = new List<betObject>();
        public receipt()
        {
            InitializeComponent();

            string data = "?batchId=" + Application.Current.Properties["currBetList"].ToString();
            string urlPath = Application.Current.Properties["ApiUrl"].ToString() + "/GetBetListByBatch";
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




            var lstView = new ListView();

            string[] arr4 = new string[4];
            int i = 0;
            foreach (var itm in betList)
            {
                arr4[i] = itm.bet_number.ToString();
                i++;
            }
            lstView.ItemsSource = arr4;


            Content = lstView;



        }

        class Objects : ViewCell
        {
            public Objects()
            {
                Label tempLabel = new Label
                {
                    Text = "Objects Placeholder" // this will be overwritten at runtime with the data in the List (see binding below)!!
                };
                //
                tempLabel.SetBinding(Label.TextProperty, "bet_type"); // Define the binding to cField1 in the List !!
                                                                     //
                var sLayout = new StackLayout();
                sLayout.Children.Add(tempLabel);
                this.View = sLayout;
            }
        }
    }
}