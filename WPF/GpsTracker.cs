using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace WPF
{
    public partial class GpsTracker : Form
    {
        

        public GpsTracker()
        {
            InitializeComponent();
        }

        private async void UpdatePoint_Click(object sender, EventArgs e)
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://192.168.237.29:5140/api/");

                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                const string login = "stickmanuk228";

                const string password = "55214Artem#";

                var request = new RequestToServer();

                var authorizeObj = await request.Authorize(login, password, httpClient);

                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + authorizeObj.Token);

                var point = await request.UpdatePoint(httpClient);

                propertyGrid1.SelectedObject = point;

                info.BackColor = Color.GreenYellow;
                info.Text = "Sended";
                info.Visible = true;
            }
            catch (Exception exception)
            {
                info.BackColor = Color.Red;
                info.Text = "Not sended";
                info.Visible = true;
                Console.WriteLine(exception);
                throw;
            }
        }
    }

    public class RequestToServer
    {
        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public async Task<AuthorizeResponse> Authorize(string login, string password, HttpClient httpClient)
        {
            HttpResponseMessage request = await httpClient.PostAsync("Login/Login/",
                new StringContent(JsonSerializer.Serialize(new AuthenticateRequest { UserName = login, Password = password }),
                    Encoding.UTF8, "application/json"));

            if (request.IsSuccessStatusCode)
            {
                string stringResult = await request.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<AuthorizeResponse>(stringResult, options);
            }
            else
            {
                throw new Exception("Request error. Status code: " + request.StatusCode);
            }
        }

        public async Task<GeoLocationRequest> UpdatePoint(HttpClient httpClient)
        {

            const string animalId = "5b034310-0f7e-4284-b867-e4237a0c594b";

            var animal = new GeoLocationRequest()
            {
                Latitude = new Random().NextDouble(-90.000000, 90.000000),
                Longitude = new Random().NextDouble(-180.000000, 180.000000),
                Alt = new Random().NextDouble(1.00, 5000.00),
            };


            var request = await httpClient.PutAsync($"Geolocator/createRandomLocation/{animalId}",
                new StringContent(JsonSerializer.Serialize(animal), Encoding.UTF8, "application/json"));

            request.EnsureSuccessStatusCode();


            return animal;
        }
    }

    [DisplayName("AuthenticateRequest"), Description("UserData")]
    public class AuthorizeResponse
    {
        [CategoryAttribute("UserAttribute"), DescriptionAttribute("IsAuthSuccessful")]
        public bool IsAuthSuccessful { get; set; }
        [CategoryAttribute("UserAttribute"), DescriptionAttribute("ErrorMessage")]
        public string ErrorMessage { get; set; }
        [CategoryAttribute("UserAttribute"), DescriptionAttribute("Token")]
        public string Token { get; set; }
    }

    public class AuthenticateRequest
    {
       
        public string UserName { set; get; } = string.Empty;
        public string Password { set; get; } = string.Empty;
    }
    [DisplayName("GeoLocationRequestClass"), Description("GeoLocation")]
    public class GeoLocationRequest
    {
        [CategoryAttribute("Location fields"), DescriptionAttribute("Latitude")]
        public double Latitude { get; set; }
        [CategoryAttribute("Location fields"), DescriptionAttribute("Longitude")]
        public double Longitude { get; set; }
        [CategoryAttribute("Location fields"), DescriptionAttribute("Alt")]
        public double Alt { get; set; }
    }
    public static class RandomExtensions
    {
        public static double NextDouble(
            this Random random,
            double minValue,
            double maxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}
