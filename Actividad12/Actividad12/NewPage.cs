using System;

using Xamarin.Forms;

namespace Actividad12
{
	public class NewPage
	{
		public static Page GetMainPage ()
		{	
			return new NavigationPage (new App());
		}
	}
		
}


