using SampleApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleApp.ViewModel
{
    public class MediaVM:BaseViewModel
    {
        public MediaVM(INavigation nav)
        {

        }
        public async Task GetList()
        {
            mediaList = new List<MusicModel>()
            {
            new MusicModel{ Id=1,Name="Chef JooYoung",Description="Chef Joo Young",MediaFile="ChefJooYoung.mp4"},
            new MusicModel{ Id=2,Name="HE RA",Description="He ra offical shot with Lee Joo Young",MediaFile="JooYoungHera.mp4"},
            new MusicModel{ Id=3,Name="JooYoung's Lovely Tig",Description="With Tig",MediaFile="JYwithTig.mp4"},
            new MusicModel{ Id=4,Name="Cute JooYoung",Description="Cute Joo Young",MediaFile="LJYCute.mp4"},
            };
        }
        private List<MusicModel> _mediaList { get; set; }
        public List<MusicModel> mediaList
        {
            get { return _mediaList; }
            set
            {
                if (_mediaList != value)
                {
                    _mediaList = value;
                    OnPropertyChanged("mediaList");
                }
            }
        }
    }
}
