using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Actividad11
{
	public class App:Application
	{
		public App() 
		{
			var carousel = new CarouselPage ();
			var p = new Contenido ();
			var q = new Contenido2 ();
			carousel.Children.Add (p);
			carousel.Children.Add (q);
			MainPage = carousel;
		}
	}
}

