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
    public partial class EntryTest : ContentPage
    {
        public EntryTest()
        {
            InitializeComponent();

            MainParallax.DestroyParallaxView();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        private void btn_Timer(object sender, EventArgs e)
        {

        }
    }
}