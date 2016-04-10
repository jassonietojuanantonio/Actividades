using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Actividad10
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			
			List<ContentPage> pages = new List<ContentPage> ();

			Color[] colors = { Color.Red, Color.Green, Color.Blue };

			foreach (Color c in colors) {
				pages.Add (new ContentPage { Content = new StackLayout {


						Children = {
							new BoxView {
								Color = c,
								VerticalOptions = LayoutOptions.FillAndExpand
							}
						}
					}
				});
			}
				
			return new CarouselPage {
				Children = { pages [0],
					pages [1],
					pages [2] }
			};
		}
	}
}

