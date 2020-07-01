using SampleApp.ViewModel;
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
    public partial class MediaPage : ContentPage
    {
        protected MediaVM mediaVM;
        public MediaPage()
        {
            InitializeComponent();
            mediaVM = new MediaVM(Navigation);
            this.BindingContext = mediaVM;
        }
    }
}