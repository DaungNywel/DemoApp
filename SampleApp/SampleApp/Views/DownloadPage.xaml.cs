using SampleApp.Interfaces;
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
    public partial class DownloadPage : ContentPage
    {
        IDownloader downloader = DependencyService.Get<IDownloader>();
        public DownloadPage()
        {
            InitializeComponent();
            //downloader.OnFileDownloaded += OnFileDownloaded;
            
        }

        private void Download_Click(object sender, EventArgs e)
        {
            Xamarin.Forms.MessagingCenter.Send<string>("", "DownloadVideoFile");
            //downloader.DownloadFile("https://vivek.blob.core.windows.net/vivekfiles/20200117050741_Sea-4006.mp4", "XF_Downloads");
        }
        private void OnFileDownloaded(object sender, DownloadEventArgs e)
        {
            if (e.FileSaved)
            {
                DisplayAlert("XF Downloader", "File Saved Successfully", "Close");
            }
            else
            {
                DisplayAlert("XF Downloader", "Error while saving the file", "Close");
            }
        }

       
    }
}