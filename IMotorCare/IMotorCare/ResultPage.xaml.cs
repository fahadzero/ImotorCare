using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IMotorCare
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : ContentPage
    {
        public string JsonString { get; set; }
        private List<ToDisplay> GetPeople(List<Person> fromGarage)
        {
            List<ToDisplay> tempList = new List<ToDisplay>();
            foreach (var person in fromGarage)
            {
                var name = $"{person.fname} {person.lname}";
                var image = Convert.FromBase64String(person.byte_image);
                var imageSource = ImageSource.FromStream(() => new MemoryStream(image));

                tempList.Add(new ToDisplay
                {
                    Id = person.id,
                    Name = name,
                    Contact = person.contact,
                    GarageAddress = person.garage_address,
                    GarageName = person.garage_name,
                    DisplayImage = imageSource,
                    Lattitude = person.lattitude,
                    Longitude = person.longitude,
                    Speciality = person.speciality,
                    Type = person.type
                });
            }
            return tempList;
        }
        public ResultPage(string json)
        {
            InitializeComponent();
            JsonString = json;
            Display();
        }
        private async void Display()
        {
            var garageData = JsonConvert.DeserializeObject<Garage>(JsonString);
            if (garageData.status_message == "Data not found")
            {
                await DisplayAlert("Error", garageData.status_message, "Ok");
                return;
            }
            ResultList.ItemsSource = GetPeople(garageData.Data.People);
        }
    }
    public class ToDisplay
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Longitude { get; set; }
        public string Lattitude { get; set; }
        public string GarageName { get; set; }
        public string GarageAddress { get; set; }
        public string Speciality { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public ImageSource DisplayImage { get; set; }
    }
}