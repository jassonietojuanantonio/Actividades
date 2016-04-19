using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Actividad11
{
	public class Contenido2 : ContentPage
	{
		public Contenido2 ()
		{
			//El control ListView muestra el contenido en forma de tabla 
			//Con RowHeight le indicamos el alto de cada renglón
			var listView = new ListView
			{
				RowHeight = 70
			};

			//Le indicamos al ListView de donde tomar los datos
			listView.ItemsSource = ObtenListaFrutas();
			//Le indicamos al listview que plantilla utilizar
			listView.ItemTemplate = new DataTemplate(typeof(FrutasCell));

			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { listView }
			};
		}
		public List<Frutas> ObtenListaFrutas()
		{
			var lista = new List<Frutas> ();

			lista.Add (new Frutas{Nombre = "Fresa", Imagen = "http://tipsdemedicina.com/wp-content/uploads/2013/05/fresas-para-el-acne5.jpg"});
			lista.Add (new Frutas{Nombre = "Manzana", Imagen = "http://mejorconsalud.com/wp-content/uploads/2014/06/manzanas-378x252.jpg"});


			return lista;
		}

	}
}


