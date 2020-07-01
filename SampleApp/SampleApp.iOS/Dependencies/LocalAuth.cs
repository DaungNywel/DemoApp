using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using LocalAuthentication;
using SampleApp.Interfaces;
using SampleApp.iOS.Dependencies;
using UIKit;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(LocalAuth))]
namespace SampleApp.iOS.Dependencies
{
    public class LocalAuth:ILocalAuth
    {
        public bool AuthenticateUser()
        {
            bool result = false;
            var context = new LAContext();
            if (context.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, out NSError authError))
            {
                var replyHandler = new LAContextReplyHandler((success, error) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        if (success)
                        {
                            // user authenticated
                            Xamarin.Forms.MessagingCenter.Send<string>("", "SuccessfullyAuthenticated");
                            result = true;
                        }
                        else
                        {
                            // user not authenticated
                            Xamarin.Forms.MessagingCenter.Send<string>("", "AuthenticationFailed");
                            result = false;
                        }
                    });
                });
                context.EvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, "Authenticate", replyHandler);
            }
            return result;
        }
    }
}