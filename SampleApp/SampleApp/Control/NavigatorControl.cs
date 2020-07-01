using SampleApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SampleApp.Control
{
    public class NavigatorControl
    {
        public static NavigatorModel SetNavigator(NavigatorModel model, INavigation Navigation, string PageName)
        {
            model.HomeIconSource = ImageSource.FromFile(PageName == "Home" ? "IconTabHomeActive" : "IconTabHome");
            model.HomeCommand = new Command(() => Home_Click(Navigation)); // Home           
            model.MoreCommand = new Command(() => More_Click(Navigation)); // More
            model.BackCommand = new Command(() => Back_Clicked(Navigation)); // Back
            return model;
        }

        private static void Back_Clicked(INavigation navigation)
        {
            //throw new NotImplementedException();
        }

        private static void More_Click(INavigation navigation)
        {
            //throw new NotImplementedException();
        }

        private static void Home_Click(INavigation navigation)
        {
           // throw new NotImplementedException();
        }
    }
}
