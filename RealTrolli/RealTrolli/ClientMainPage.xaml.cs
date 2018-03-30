﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealTrolli
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClientMainPage : ContentPage
	{
		public ClientMainPage (string name)
		{
			InitializeComponent ();
            value.Text += " " + name;
        }
	}
}