using System;
using Xamarin.Forms;
using System.Net.Http;
using System.Collections.Generic;

namespace Actividad5
{
	public class App
	{
		public static NavigationPage GetMainPage ()
		{	
			Entry usuario = new Entry { Placeholder = "Usuario" };
			Entry clave = new Entry { Placeholder = "Clave", IsPassword = true };
			Button btnLogin = new Button {
				Text = "Login",
				TextColor = Color.White,
				BackgroundColor = Color.FromHex ("77D065")
			};

			ContentPage contentPage = new ContentPage();
			contentPage.Content = new StackLayout {
				Padding = 5,
				VerticalOptions = LayoutOptions.End,
				Children = {
					usuario,
					clave,
					btnLogin
				}
			};
			btnLogin.Clicked += async (object sender, EventArgs e) => {
				using (var client = new HttpClient()) {
					var content = new FormUrlEncodedContent(new[] {
						new KeyValuePair<string, string>("username", usuario.Text),
						new KeyValuePair<string, string>("password", clave.Text)
					});

					using (var response = await client.PostAsync("http://212.47.237.211/login", content)) {
						using (var responseContent = response.Content) {
							var result = await responseContent.ReadAsStringAsync();
							await contentPage.DisplayAlert("Respuesta del servidor",result,"OK","");

							var todoPage = new NewPage(); // so the new page shows correct data
							await contentPage.Navigation.PushAsync(todoPage);
						}
					}
				}

			};
			return new NavigationPage(contentPage);
		}
	}
}

