
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
    public partial class MasterPage : ContentPage
    {
        protected NewsVM _newsVM;
        int slidePosition = 0;
        public MasterPage()
        {
            InitializeComponent();
            _newsVM = new NewsVM(this.Navigation);
            this.BindingContext = _newsVM;
            _newsVM.GetList();
            carouselForm.ItemsSource = _newsVM.newsList;
            indicatorview.ItemsSource = _newsVM.newsList;
            Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
            {
                indicatorview.Position = (indicatorview.Position + 1) % _newsVM.newsList.Count;
                carouselForm.Position = (carouselForm.Position + 1) % _newsVM.newsList.Count;

                // slidePosition++;
                // if (slidePosition == _newsVM.newsList.Count) slidePosition = 0;
                //indicatorview.Position = (indicatorview.Position + 1) % _newsVM.newsList.Count;
                // carouselForm.Position = slidePosition;
                return true;
            }));
        }
    }
}