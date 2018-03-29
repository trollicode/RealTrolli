using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RealTrolli
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            if (Application.Current.Properties.ContainsKey("id"))
            {

                var id = Application.Current.Properties["id"];
                test.Text = "Recorded "+id;
                // do something with id
            }
        }

        public void btn(object sender, EventArgs e) {

            string id = get.Text;
            Application.Current.Properties["id"] = id;


        }
	}
}
