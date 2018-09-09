using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace thaibet.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Bet3d : ContentPage
	{
		public Bet3d ()
		{
			InitializeComponent ();

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

        }

        public void OnClicked(object o, EventArgs e)
        {
            //bool isValid = false;
            //UserAuthenticated();

            //var nameValue = userNm.Text;
        }
    }
}