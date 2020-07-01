using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace SampleApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationPage : ContentPage
    {
        public LocationPage()
        {
            InitializeComponent();
            //var map = new Map(MapSpan.FromCenterAndRadius(new Position(13.7433, 100.538103), Distance.FromMiles(10)));
            
            //map.Pins.Add(pin);
            CreateMaps();
            
        }
        private async void CreateMaps()
        {
            //var locator = CrossGeolocator.Current;
           // locator.DesiredAccuracy = 50;
            //var location = await locator.GetPositionAsync(TimeSpan.FromTicks(10000));
            var map = new Map(MapSpan.FromCenterAndRadius(new Position(13.7433, 100.538103), Distance.FromMiles(0.3)));
           
            var pin = new Pin()
            {
                Type = PinType.Place,
                Position = new Position(13.7433, 100.538103),
                Label = "Some Pin!",
                Address = "OFFICE"
            };

            var position = new Position(13.7433, 100.538103);
            map.Pins.Add(pin);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(13.7433, 100.538103), Distance.FromMiles(1)));
            TestMap.Children.Add(map);
        }
    }
}