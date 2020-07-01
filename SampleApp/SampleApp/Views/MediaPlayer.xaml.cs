
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MediaPlayer : ContentPage
    {
        private string videoUrl = "https://sec.ch9.ms/ch9/e68c/690eebb1-797a-40ef-a841-c63dded4e68c/Cognitive-Services-Emotion_high.mp4";
        private string audioUrl = "https://vivek.blob.core.windows.net/vivekfiles/KrisWu_TianDi.mp3";
        public MediaPlayer()
        {
            InitializeComponent();
        }

        private void PlayStopButton(object sender, EventArgs e)
        {
            if (PlayStopButtonText.Text == "Play")
            {
                CrossMediaManager.Current.Pause();

                PlayStopButtonText.Text = "Stop";
            }
            else if (PlayStopButtonText.Text == "Stop")
            {
                CrossMediaManager.Current.Play(audioUrl, MediaFileType.Audio);

                PlayStopButtonText.Text = "Play";
            }
           TimeSpan data = CrossMediaManager.Current.Position;
          //  pos=data.
        }
    }
}