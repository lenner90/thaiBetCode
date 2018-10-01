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
	public partial class action : ContentPage
	{
		public action ()
		{
			InitializeComponent ();
		}

        public void OnClickNew(object o, EventArgs e)
        {
            Navigation.PushAsync(new BetType() { Title = "New" });
        }

        public void OnClickHistory(object o, EventArgs e)
        {
            Navigation.PushAsync(new History() { Title = "History" });
        }

        //OnClickBetLimit
        public void OnClickBetLimit(object o, EventArgs e)
        {
            Navigation.PushAsync(new BetLimit() { Title = "Bet Limit" });
        }
    }
}