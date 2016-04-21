using System;
using Xamarin.Forms;
using System.Net.Http;
using System.Collections.Generic;

namespace Actividad9
{
	public class Login: ContentPage
	{
		public Login ()
		{
			Entry usuario = new Entry { Placeholder = "Usuario" };
			Entry clave = new Entry { Placeholder = "Clave", IsPassword = true };

			Button boton = new Button {
				Text = "Login",
				TextColor = Color.White,
				BackgroundColor = Color.FromHex ("77D065") 
			};

			boton.Clicked += async (sender, e) => {

				using (var client = new HttpClient ()) {
					var content = new FormUrlEncodedContent (new[] {
						new KeyValuePair<string, string> ("user", usuario.Text),
						new KeyValuePair<string, string> ("password", clave.Text)
					});

					using (var response = await client.PostAsync ("http://104.42.52.205/mobile/login", content)) {
						using (var responseContent = response.Content) {
							var result = await responseContent.ReadAsStringAsync ();
							string a=result.ToString();
							if (a.Equals("{\"status\":\"ok\"}")){
								await DisplayAlert ("Respuesta del servidor", result, "OK", "");
								var todoPage = new Contenido (); // so the new page shows correct data
								await Navigation.PushAsync (todoPage);
							} else {
								await DisplayAlert ("Respuesta del servidor", "No aceptado", "OK", "");
							}
				
								
						}
					}
				}
			};

			//Stacklayout permite apilar los controles verticalmente
			StackLayout stackLayout = new StackLayout
			{
				Padding = 5,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Children =
				{
					usuario,
					clave,
					boton
				}
				};

			//Como esta clase hereda de ContentPage, podemos usar estas propiedades directamente
			this.Content = stackLayout;
			this.Padding = new Thickness (5, Device.OnPlatform (20, 5, 5), 5, 5);
		}
	}
}

