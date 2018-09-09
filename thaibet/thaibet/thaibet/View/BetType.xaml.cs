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
	public partial class BetType : ContentPage
	{
		public BetType ()
		{
			InitializeComponent ();
		}

        public void OnClick2d(object o, EventArgs e)
        {
            Navigation.PushAsync(new Bet2d());
        }

        public void OnClick3d(object o, EventArgs e)
        {
            Navigation.PushAsync(new Bet3d());
        }
    }
}