using SampleApp.Model;
using SampleApp.PublicClass;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleApp.ViewModel
{
    public class NewsVM:BaseViewModel
    {
        public NewsVM(INavigation _Nav)
        {
            ProfileCommand = new DelegateCommand(ProfileAsync);
            MediaCommand = new DelegateCommand(MediaAsync);
            MoreCommand = new DelegateCommand(MoreAsync);
            ProfileCommand = new DelegateCommand(ProfileAsync);
            
        }

        private void MoreAsync(object obj)
        {
            Navigation.PushModalAsync(new Views.HomePage(), true);
            //throw new NotImplementedException();
        }

        private void MediaAsync(object obj)
        {
            Navigation.PushModalAsync(new Views.MediaPage(),true);
            //throw new NotImplementedException();
        }

        public async Task GetList()
        {
            newsList = new List<NewsModel>()
            {
            new NewsModel{ id=1,sourceImg="imgx"},
            new NewsModel{ id=2,sourceImg="jooyoungcute"},
            new NewsModel{ id=3,sourceImg="jooyounglove"},
            new NewsModel{ id=4,sourceImg="joyoungsmile"},
            new NewsModel{ id=5,sourceImg="imgxx"},
            };
        }
        private void ProfileAsync(object obj)
        {

            //MasterDetailPage masterDetailPage = new MasterDetailPage();
            ////masterDetailPage.Master = new SampleApp.Views.HomePage();
            //masterDetailPage.Detail = new NavigationPage(new Views.HomePage());
            //// Navigation.PushModalAsync(new Views.HomePage(), true);
            //App.Current.MainPage = masterDetailPage;
        }

        public DelegateCommand ProfileCommand { get; }
        public DelegateCommand NotificationCommand { get; }
        public DelegateCommand HomeCommand { get; }
        public DelegateCommand MediaCommand { get; }
        public DelegateCommand MoreCommand { get; }

        private List<NewsModel> _newsList { get; set; }
        public List<NewsModel> newsList
        {
            get { return _newsList; }
            set
            {
                if (_newsList != value)
                {
                    _newsList = value;
                    OnPropertyChanged("newsList");
                }
            }
        }


    }
}
