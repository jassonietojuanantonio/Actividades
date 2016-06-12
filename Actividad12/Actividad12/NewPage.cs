using System;

using Xamarin.Forms;

namespace Actividad12
{
	public class NewPage : ContentPage
	{
		public NewPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


