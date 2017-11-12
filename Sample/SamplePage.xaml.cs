using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Xamarin.Forms;

namespace Sample
{
    public partial class SamplePage : ContentPage
    {
        public SamplePage()
        {
            InitializeComponent();
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            Task.Run(async () => {
                var weather = await GetWeather();
                Device.BeginInvokeOnMainThread(() => {
                    var forecast = weather["forecasts"][1];
                    this.DateLabel.Text = forecast["date"];
                    this.TelopLabel.Text = forecast["telop"];
                    this.MinTemp.Text = forecast["temperature"]["min"]["celsius"];
                    this.MaxTemp.Text = forecast["temperature"]["max"]["celsius"];
                });
            });
        }
        
        private async Task<dynamic> GetWeather()
        {
            var client = new HttpClient();
            
            var uri = "http://weather.livedoor.com/forecast/webservice/json/v1?city=016010";
            var json = await client.GetStringAsync(uri);
            var weather = JsonConvert.DeserializeObject<dynamic>(json);
            
            return weather;
        }
    }
}
