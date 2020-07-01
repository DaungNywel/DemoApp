using FormsVideoLibrary;
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
    public partial class CustomPositionBarPage : ContentPage
    {
        public CustomPositionBarPage()
        {
            InitializeComponent();
           
            //videoPlayer.Source = VideoSource.FromUri("https://archive.org/download/BigBuckBunny_328/BigBuckBunny_512kb.mp4");
            //videoPlayer.Source = VideoSource.FromUri("https://vivek.blob.core.windows.net/vivekfiles/20200117050741_Sea-4006.mp4");
        }

        private void OnPlayPauseButtonClicked(object sender, EventArgs e)
        {

        }
    }
}