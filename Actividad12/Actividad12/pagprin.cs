using System;

using Xamarin.Forms;

namespace Actividad12
{
	public class pagprin : ContentPage
	{
		public pagprin ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


