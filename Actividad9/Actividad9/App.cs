using System;
using Xamarin.Forms;

namespace Actividad9
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new NavigationPage (new Login());
		}
	}
}

