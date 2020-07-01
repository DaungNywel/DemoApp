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
    public partial class SignUp : ContentPage
    {
        //protected SignUpViewModel _signUpVM;
        public SignUp()
        {
            InitializeComponent();
           // _signUpVM = new SignUpViewModel(this.Navigation);
            //this.BindingContext = _signUpVM;
        }
    }
}