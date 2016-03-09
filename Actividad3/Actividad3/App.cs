using System;
using Xamarin.Forms;

namespace Actividad3
{
	public class App
	{
		public static Page GetMainPage ()
		{
			return new ContentPage { 
				Content = new Button {
					Text = "A Jasso",
					VerticalOptions = LayoutOptions.CenterAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
				},
			};
		}
	}
}
