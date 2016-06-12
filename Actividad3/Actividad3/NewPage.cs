using System;

using Xamarin.Forms;

namespace Actividad3
{
	public class Page2 : ContentPage
	{
		public Page2 (string a)
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = a }
				}
			};
		}
	}
}


