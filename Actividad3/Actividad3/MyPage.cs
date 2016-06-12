using System;

using Xamarin.Forms;

namespace Actividad3
{
	public class NewPage
	{
		public static Page GetMainPage ()
		{	
			return new NavigationPage (new App());
		}
	}

}


