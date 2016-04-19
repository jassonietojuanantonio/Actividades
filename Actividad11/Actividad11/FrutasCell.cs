using System;
using Xamarin.Forms;

namespace Actividad11
{
	public class FrutasCell: ViewCell
	{
		public FrutasCell ()
		{
			var imagen = new Image
			{
				Aspect = Aspect.AspectFit,

			};

			imagen.SetBinding(Image.SourceProperty, new Binding("Imagen"));
			imagen.WidthRequest = imagen.HeightRequest = 70;

			var nombre = new Label
			{
				HorizontalOptions= LayoutOptions.FillAndExpand
			};
			nombre.SetBinding(Label.TextProperty, "Nombre");

			var viewLayout = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				Children = { imagen, nombre }
			};
			View = viewLayout;

		}
	}
}

