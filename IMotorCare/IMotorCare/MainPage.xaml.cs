using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IMotorCare
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async Task<string> Send(string type)
        {
            try
            {

                var postData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("key", "123"),
                    new KeyValuePair<string, string>("type", type)
                };

                FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("http://localhost")
                };

                HttpResponseMessage response = await client.PostAsync($"http://localhost/api/", content);
                return response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.ToString(), "Ok");
                return "";
            }
        }
        private async void FindBreakdown_Clicked(object sender, EventArgs e)
        {
            var jsonString = await Send("breakdown");
            if (!string.IsNullOrEmpty(jsonString))
                await Navigation.PushAsync(new ResultPage(jsonString));
        }

        private async void FindMechanic_Clicked(object sender, EventArgs e)
        {
            var jsonString = await Send("mechanic");
            if (!string.IsNullOrEmpty(jsonString))
                await Navigation.PushAsync(new ResultPage(jsonString));
        }
    }
}
