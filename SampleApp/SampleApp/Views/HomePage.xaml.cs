using SampleApp.Control;
using SampleApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }       
        private void MediaPlayer_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MediaPlayer());
        }

        private void Location_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new EntryTest());
        }

        private void Download_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new DownloadPage());
        }

        private void DefaultPlayer_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new DefaultPlayer());
        }

        private void CustomPositionBar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CustomPositionBarPage());
        }

        private void CameraPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CameraPage());
        }

        private void FBLogin_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IFacebook>().facebook();
        }
    }
}