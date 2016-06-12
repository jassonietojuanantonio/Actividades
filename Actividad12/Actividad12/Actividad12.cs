using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Http;
using Xamarin.Forms;
using System.Json;

namespace Actividad12
{
	public class App : ContentPage
	{
		public class Weather
		{
			public string Title { get; set; }
			public string Temperature { get; set; }
			public string Wind { get; set; }
			public string Humidity { get; set; }
			public string Visibility { get; set; }
			public string Sunrise { get; set; }
			public string Sunset { get; set; }
		}
		public class DataService
		{
			public static async Task<dynamic> getDataFromService(string queryString)
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(queryString);

				var response = await request.GetResponseAsync().ConfigureAwait(false);
				var stream = response.GetResponseStream();

				var streamReader = new StreamReader(stream);
				string responseText = streamReader.ReadToEnd();

				dynamic data = responseText;

				return data;
			}

		}
		public static async Task<Weather> GetWeather(string zipCode)
		{
			string queryString = 
				"https://query.yahooapis.com/v1/public/yql?q=select+*+from+weather.forecast+where+location=" +
             zipCode + "&format=json";


			dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

			dynamic weatherOverview = results["query"]["results"]["channel"];

			if ((string)weatherOverview["description"] != "Yahoo! Weather Error")
			{
				Weather weather = new Weather();

				weather.Title = (string)weatherOverview["description"];

				dynamic wind = weatherOverview["wind"];
				weather.Temperature = (string)wind["chill"];
				weather.Wind = (string)wind["speed"];

				dynamic atmosphere = weatherOverview["atmosphere"];
				weather.Humidity = (string)atmosphere["humidity"];
				weather.Visibility = (string)atmosphere["visibility"];

				dynamic astronomy = weatherOverview["astronomy"];
				weather.Sunrise = (string)astronomy["sunrise"];
				weather.Sunset = (string)astronomy["sunset"];

				return weather;
			}
			else
			{
				return null;
			}
		}
	}

}
