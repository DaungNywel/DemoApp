using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // Handle when your app starts
            #region MasterDetailPage
            MasterDetailPage masterDetailPage = new MasterDetailPage();
            masterDetailPage.Master = new Views.HomePage() { Title = "Hello Master", Icon = new FileImageSource() { File = "GrayCircle.png" } };
            masterDetailPage.Detail = new NavigationPage(new Views.MasterPage());
            // หน้าหลัก
            App.Current.MainPage = masterDetailPage;
            #endregion
            // MainPage = new Views.TestOTP();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
