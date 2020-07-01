using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SampleApp.Droid.DependencyServices;
using SampleApp.Interface;
using SampleApp.ViewModel;
using Xamarin.Auth;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(FacebookAuth))]
namespace SampleApp.Droid.DependencyServices
{
    public class FacebookAuth : BaseViewModel, IFacebook
    {
        public void facebook()
        {
            var auth = new OAuth2Authenticator(
                                              clientId: "319941352326525",
                                              scope: "email",
                                              authorizeUrl: new System.Uri("https://m.facebook.com/dialog/oauth"),
                                              redirectUrl: new System.Uri("https://www.facebook.com/connect/login_success.html"));

            auth.Completed += Auth_Completed;
            var ui = auth.GetUI((Activity)Forms.Context);
            ((Activity)Forms.Context).StartActivity(ui);
        }

        private async void Auth_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                UserDialogs.Instance.ShowLoading();
                var request = new OAuth2Request(
                                                "GET",
                                                new System.Uri("https://graph.facebook.com/me?fields=email,name,first_name,last_name,gender,picture"),//https://graph.facebook.com/me?fields=name,picture,cover,birthday //https://graph.facebook.com/me?fields=email,name,first_name,last_name,gender,picture
                                                null,
                                                e.Account);

                var fbResponse = await request.GetResponseAsync();

                //var fbUserAccessToken = CrossFacebookClient.Current.ActiveToken;
                var obj = JObject.Parse(fbResponse.GetResponseText());
                var email = string.Empty;
                try
                {
                    email = obj["email"].ToString().Replace("\"", "");
                }
                catch (Exception ex)
                {
                    email = "psycho@gmail.com";
                }
                var FacebookAccessToken = e.Account.Properties["access_token"];
                var json = fbResponse.GetResponseText();
               // var fbUser = JsonConvert.DeserializeObject<FacebookUserModel>(json);
                //var name = fbUser.name;
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