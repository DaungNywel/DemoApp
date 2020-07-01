using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UIKit;
using Xamarin.Auth;
using Xamarin.Forms;
using SampleApp.Interface;
using SampleApp.iOS.DependencyServices;

[assembly: Dependency(typeof(FacebookAuth))]
namespace SampleApp.iOS.DependencyServices
{
    public class FacebookAuth : IFacebook
    {
        public UIViewController vc;

        public void facebook()
        {
            try
            {
                var auth = new OAuth2Authenticator(
                                                  clientId: "232638541402649",
                                                  scope: "email",
                                                  authorizeUrl: new System.Uri("https://m.facebook.com/dialog/oauth"),
                                                  redirectUrl: new System.Uri("https://www.facebook.com/connect/login_success.html"),
                                                  isUsingNativeUI: false);

                auth.Completed += Auth_Completed;
                vc = new UIViewController();
                vc = auth.GetUI();
                var window = UIApplication.SharedApplication.KeyWindow;
                var currvc = window.RootViewController;
                while (currvc.PresentedViewController != null)
                {
                    currvc = currvc.PresentedViewController;
                }
                auth.ShowErrors = false;
                var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
                presenter.Login(auth);
            }
            catch (Exception ex)
            { }
            //vc.PresentViewController(auth.GetUI(), true, null);
        }

        private async void Auth_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                var request = new OAuth2Request(
                                                "GET",
                                                new System.Uri("https://graph.facebook.com/me?fields=email,name,first_name,last_name,gender,picture"),
                                                null,
                                                e.Account);

                var fbResponse = await request.GetResponseAsync();
                var obj = JObject.Parse(fbResponse.GetResponseText());
                var email = obj["email"].ToString().Replace("\"", "");
                var FacebookAccessToken = e.Account.Properties["access_token"];
                var json = fbResponse.GetResponseText();
                //var fbUser = JsonConvert.DeserializeObject<FacebookUserModel>(json);
               // var name = fbUser.name;
                //Helper.Constants.AuthUserEmail = email;
                //Helper.Constants.AuthUserFName = fbUser.name;
                //Helper.Constants.AuthUserLName = fbUser.last_name;
                //Helper.Constants.AuthUserPhone = string.Empty;
                //Helper.Constants.AuthUserProfilePic = fbUser.picture.data.url;
                //Xamarin.Forms.MessagingCenter.Send<string>(Convert.ToString(Helper.Constants.isAuthLogin), "AuthLogin");
            }
        }
    }
}