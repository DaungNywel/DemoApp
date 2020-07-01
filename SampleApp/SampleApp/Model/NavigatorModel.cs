using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.Model
{
   public class NavigatorModel
    {
        public ICommand BackCommand { get; set; }    
        public ICommand HomeCommand { get; set; }    
        public ICommand MoreCommand { get; set; }

        public ImageSource HomeIconSource { get; set; }       
        public ImageSource MoreIconSource { get; set; }
    }
}
