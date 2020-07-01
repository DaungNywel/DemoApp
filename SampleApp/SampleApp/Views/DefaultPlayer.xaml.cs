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
    public partial class DefaultPlayer : ContentPage
    {
        VideoPlayer playVideo;
        public DefaultPlayer()
        {
            InitializeComponent();
            //playVideo = new VideoPlayer
            //{
            //    Source = VideoSource.FromUri("https://archive.org/download/BigBuckBunny_328/BigBuckBunny_512kb.mp4"),
            //    HeightRequest = (Xamarin.Forms.Application.Current.MainPage.Height - 150)
            //};

        }
    }
}