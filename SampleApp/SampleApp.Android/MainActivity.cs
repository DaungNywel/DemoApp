using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android;
using Android.Content;
using System.Threading.Tasks;
using Xamarin.Forms;
using Acr.UserDialogs;
using Java.IO;
using Plugin.Media;
using Plugin.CurrentActivity;

namespace SampleApp.Droid
{
    [Activity(Label = "SampleApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const int RequestLocationId = 0;

        readonly string[] LocationPermissions =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation
        };


        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            Plugin.MediaManager.Forms.Android.VideoViewRenderer.Init();
            base.OnCreate(savedInstanceState);
            CrossMedia.Current.Initialize();
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            MessagingCenter.Subscribe<string>(this, "DownloadVideoFile", (sender) =>
            {
                //string temp = Helpers.Settings.DownloadFile;
                Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                {
                    DownloadVideoFile("https://archive.org/download/ElephantsDream/ed_hd_512kb.mp4");
                   // DownloadVideoFile(temp);
                });
            });
            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            UserDialogs.Init(this);
            LoadApplication(new App());
        }
        public static MainActivity Current { private set; get; }

        public static readonly int PickImageId = 1000;

        public TaskCompletionSource<string> PickImageTaskCompletionSource { set; get; }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == PickImageId)
            {
                if ((resultCode == Result.Ok) && (data != null))
                {
                    // Set the filename as the completion of the Task
                    PickImageTaskCompletionSource.SetResult(data.DataString);
                }
                else
                {
                    PickImageTaskCompletionSource.SetResult(null);
                }
            }
        }
        protected override void OnStart()
        {
            base.OnStart();

            if ((int)Build.VERSION.SdkInt >= 23)
            {
                if (CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Permission.Granted)
                {
                    RequestPermissions(LocationPermissions, RequestLocationId);
                }
                else
                {
                    // Permissions already granted - display a message.
                }
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public async void DownloadVideoFile(string _url)
        {
            try
            {
                //For Downloading .Apk File...
                //UserDialogs.Instance.ShowLoading("Downloding...");
                await Task.Run(async () =>
                {
                    System.String destination = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads) + "/";
                    System.String fileName = "video" + System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".mp4";
                    destination += fileName;
                    Android.Net.Uri uri = Android.Net.Uri.Parse("file://" + destination);

                    //Delete update file if exists
                    File file = new File(destination);
                    if (file.Exists())
                        //file.delete() - test this, I think sometimes it doesnt work
                        file.Delete();

                    //get url of app on server
                    Android.Net.Uri _uri = Android.Net.Uri.Parse(_url);
                    //Helpers.Constants.MusicPath = destination;
                    //set downloadmanager
                    DownloadManager.Request request = new DownloadManager.Request(_uri);
                    request.SetTitle("video" + System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".mp4");

                    //set destination
                    request.SetDestinationUri(uri);

                    // get download service and enqueue file
                    DownloadManager manager = (DownloadManager)GetSystemService(Context.DownloadService);
                    long downloadId = manager.Enqueue(request);

                    Xamarin.Forms.MessagingCenter.Send<string>("", "SaveVideo");
                    UserDialogs.Instance.HideLoading();
                }).ConfigureAwait(false);

            }
            catch (System.Exception ex)
            { }
            UserDialogs.Instance.HideLoading();
        }
    }
}