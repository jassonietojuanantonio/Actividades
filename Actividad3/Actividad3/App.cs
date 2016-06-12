using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Http;
using Xamarin.Forms;
using System.Json;
using System;
using System.Collections.Generic;

namespace Actividad3
{
	public class App : ContentPage
	{
		private async Task<JsonValue> PlacAsync (string url)
		{
			ContentPage contentPage = new ContentPage();
			//string b;
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (url));
			request.ContentType = "application/json";
			request.Method = "GET";
			using (WebResponse response = await request.GetResponseAsync ())
			{
				using (Stream stream = response.GetResponseStream ())
				{
					JsonValue jsonDoc = await Task.Run (() => JsonObject.Load (stream));
					string a = jsonDoc.ToString();
					a = a.Replace("{","").Replace("}","");
					await DisplayAlert ("", a, "OK", "");
					return jsonDoc;
				}
			}

		}
		public App ()
		{
			Entry placa = new Entry { Placeholder = "Placa" };
			Button boton = new Button {
				Text = "Buscar",
				TextColor = Color.White,
				BackgroundColor = Color.FromHex ("77D065") 
			};

			boton.Clicked += async (sender, e) => {
				
				string url = "http://datos.labplc.mx/movilidad/vehiculos/" +
					placa.Text+".json";

				JsonValue json = await PlacAsync (url);
			};
			StackLayout stackLayout = new StackLayout
			{
				Padding = 5,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Children =
				{
					placa,
					boton
				}
				};
			this.Content = stackLayout;
			this.Padding = new Thickness (5, Device.OnPlatform (20, 5, 5), 5, 5);
		}

	}


}
